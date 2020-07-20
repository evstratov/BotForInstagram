using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Logger;
using InstaSharper.Classes.Models;
using System.IO;
using System.Diagnostics;

namespace InstagramBot
{
    public partial class InstagramBotForm : Form
    {
        private string login, password = string.Empty;

        private Logger logger;
        // мы
        private static UserSessionData user;
        private static IInstaApi api;
        // массив хэштегов
        private string[] hashtagArr;
        // массив комментариев
        private string[] commentsArr;
        // список Pk пользователей
        private List<string> folowingUsers;
        // используется для чтения разом всех Pk из файла followers.txt
        private string[] unfollowUsersAsrr;
        // сколько лайков/комментариев/подписок на каждый хэштег
        private int actionCount;
        //private Stopwatch stopwatch;
        public InstagramBotForm()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            login = login_txt.Text;
            password = password_txt.Text;
            logger = new Logger();

            if (login == "" || password == "")
                MessageBox.Show("Input login and password");
            user = new UserSessionData();
            user.UserName = login;
            user.Password = password;

            Login();
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                logBox.Items.Add("Getting started...");
                //stopwatch = Stopwatch.StartNew();
                progressBar.Value = 0;
                folowingUsers = new List<string>();

                actionCount = Convert.ToInt32(actoinsCount_txt.Text);
                //logBox.Items.Add($"{actionCount} operations will be performed");
                if (chk_boxComment.Checked)
                {
                    // считываем все строки в строковый массив
                    commentsArr = File.ReadAllLines("Sources\\comments.txt");
                }
            }
            catch (Exception ex)
            {
                logger.CloseLog();
                MessageBox.Show(ex.Message);
            }
            // чтение файла с хештегами
            using (FileStream fstream = File.OpenRead("Sources\\hashtags.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                // разбиваем текст по отдельным ключевым словам
                TextToHashtagArr(textFromFile);  
            }
        }
        private void TextToHashtagArr(string text)
        {
            hashtagArr = text.Split('#');
            progressBar.Maximum = (hashtagArr.Length - 1) * actionCount;
            foreach (string tag in hashtagArr)
            {
                if (tag != "")
                {
                    ProcessHashtag(tag);
                }
            }
        }
        private async void ProcessHashtag(string tag)
        {
            try {
                // ищем информацию о теге
                var hashtagInfo = await api.GetHashtagInfo(tag);
                if (hashtagInfo.Succeeded)
                {
                    //logBox.Items.Add("Hashtag: #" + hashtagInfo.Value.Name + ", media count = " + hashtagInfo.Value.MediaCount);
                    // получаем ленту с постами по хештегу
                    var tagFeed = await api.GetTagFeedAsync(hashtagInfo.Value.Name, PaginationParameters.MaxPagesToLoad(5));
                    int count = actionCount < (tagFeed.Value.Medias.Count) ? actionCount : tagFeed.Value.Medias.Count;
                    foreach (var media in tagFeed.Value.Medias.Take(count))
                    {
                        if (chk_boxLike.Checked)
                        {
                            // ставим лайки каждому посту
                            var likeResult = await api.LikeMediaAsync(media.InstaIdentifier);
                            var resultString = likeResult.Value ? "liked" : "not liked";
                            if (media.Images.Count > 0)
                                logger.WriteLog($"Hashtag: #{hashtagInfo.Value.Name}, URI:{media.Images[0].URI}");
                            logger.WriteLog($" Post URI: https://www.instagram.com/p/{media.Code}");
                            logger.WriteLog($"User: {media.User.UserName} {resultString}");
                        }
                        if (chk_follow.Checked)
                        {
                            // подписываемся на автора картинки
                            var followResult = await api.FollowUserAsync(media.User.Pk);
                            var resultString = followResult.Succeeded ? "followed" : "not folowwed";
                            logger.WriteLog($"{resultString} {media.User.UserName}");
                            folowingUsers.Add(media.User.Pk.ToString());
                        }
                        if (chk_boxComment.Checked && commentsArr.Length > 0)
                        {
                            // ставим случайный комментарий автору фотки
                            Random rnd = new Random();
                            int randIndx = rnd.Next(0, commentsArr.Length - 1);
                            string comment = commentsArr[randIndx];

                            var commentResult = await api.CommentMediaAsync(media.InstaIdentifier, comment);
                            var resultString = commentResult.Succeeded ? "comented" : "not comented";
                            logger.WriteLog($"{resultString}");
                            logger.WriteLog($"-------------------------------------------------------------");

                        }
                        if (media.Images.Count > 1)
                            PrintImage(media.Images[1].URI);
                        progressBar.Increment(1);
                    }
                }
            } catch (Exception ex)
            {
                logger.CloseLog();
                MessageBox.Show(ex.ToString());
            }
        }

        private async void Login()
        {
            try
            {
                // создаем  обьект, через который происходит основная работа
                api = InstaApiBuilder.CreateBuilder()
                    .SetUser(user)
                    .UseLogger(new DebugLogger(LogLevel.Exceptions))
                    .SetRequestDelay(RequestDelay.FromSeconds(7, 9))
                    .Build();
                var loginRequest = await api.LoginAsync();
                if (loginRequest.Succeeded)
                {
                    logBox.Items.Add("Logged in succes, press Start");
                    btn_start.Enabled = true;
                    btn_unfollow.Enabled = true;
                }
                else
                {
                    logBox.Items.Add("Logged in failed! " + loginRequest.Info.Message);
                }
            }
            catch (Exception ex) {
                logger.CloseLog();
                MessageBox.Show(ex.ToString());
            }
        }
        private async void PrintImage(string uri)
        {
            try {
                await Task.Run(() =>
                {
                    if (uri != "")
                        pictureBoxInst.Load(uri);
                    else
                        pictureBoxInst.Image = null;
                });
            }
            catch(Exception ex) {
                WritePkToFile();
                pictureBoxInst.Image = null;
                //logger.CloseLog();
                MessageBox.Show(ex.ToString());
            }
        }

        // запись в файд Pk пользователей на которых подписались
        private void WritePkToFile()
        {
            using (StreamWriter sw = new StreamWriter("Sources\\followers.txt", append:true))
            {
                if (folowingUsers == null || folowingUsers.Count == 0)
                    return;
                foreach (string line in folowingUsers)
                    sw.WriteLine(line);
            }
        }

        private async void btn_unfollow_Click(object sender, EventArgs e)
        {
            try
            {
                logBox.Items.Add($"Start unfollowing...");
                // дополняем файл, если только  после запуска приложения были новые подписки
                WritePkToFile();

                unfollowUsersAsrr = File.ReadAllLines("Sources\\followers.txt");
                int success = 0;
                int failed = 0;
                foreach (string pk in unfollowUsersAsrr)
                {
                    // отписка
                    var unfollowResult = await api.UnFollowUserAsync(long.Parse(pk));

                    if (unfollowResult.Succeeded)
                        success++;
                    else
                        failed++;
                }
                logBox.Items.Add($"Unfollowing complited. Successfully: { success}. Failed: {failed}.");
                logger.WriteLog($"Unfollowing complited. Successfully: { success}. Failed: {failed}.");
                if (failed == 0)
                    using (FileStream fs = File.Create("Sources\\followers.txt")) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                logger.CloseLog();
            }
            // чистим файл
        }

        private void InstagramBotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WritePkToFile();
            logger.CloseLog();
        }
    }

    public class Logger
    {
        public StreamWriter file;
        private string filename;
        public Logger()
        {
            filename = DateTime.Now.ToString("yyyy-MM-dd H.mm.ss");
            file = new StreamWriter($"Logs\\{filename}.txt", append: true);
        }
        ~Logger()
        {
            CloseLog();
        }
        public void WriteLog(string text)
        {
            file.WriteLine(text);
        }
        public void CloseLog()
        {
            file.Close();
        }
    }
}
