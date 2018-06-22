using AForge.Video;
using AForge.Video.DirectShow;
using Logger;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using pluspoint.Message;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace pluspoint.Base
{
    public partial class QRReadForm : Form
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// 値を返す用
        /// </summary>
        public string ReturnValue;

        /// <summary>
        /// ビデオデバイス
        /// </summary>
        private VideoCaptureDevice VideoSource = null;

        /// <summary>
        /// QRコード読取り
        /// </summary>
        BarcodeReader Reader = null;


        //--------------------------------------------------
        // コンストラクタ・デストラクタ・初期化系
        //--------------------------------------------------
        public QRReadForm()
        {
            try
            {
                // 自動生成のフォーム初期化
                InitializeComponent();

                // タイトルと文章の設定
                this.LbTitle.Text = "QR読取り";
                this.LbMessage.Text = "";
            }
            catch
            {
                throw;
            }
        }
        public QRReadForm(string title, string message)
        {
            try
            {
                // 自動生成のフォーム初期化
                InitializeComponent();

                // タイトルと文章の設定
                this.LbTitle.Text = title;
                this.LbMessage.Text = message;
            }
            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~QRReadForm() { }
        
        /// <summary>
        /// 終了処理
        /// </summary>
        public new void Dispose()
        {
            // カメラデータの取得停止
            VideoCaptureStop();
            // カメラデバイスの開放
            VideoSource = null;
            // QR読取りタイマーの停止
            TimerWait.Stop();
        }
        
        /// <summary>
        /// フォームサイズと位置の調整
        /// </summary>
        private void FormSizePosition()
        {
            try
            {
                // 親画面の位置取得
                int OwnerTop = Owner.Top;
                int OwnerLeft = Owner.Left;

                // 親画面のサイズを取得
                int OwnerWidth = Owner.Width;
                int OwnerHeight = Owner.Height;

                // 現時点の画面サイズ取得
                int NowWidth = this.Width;
                int NowHeight = this.Height;

                // QR読取り画面のサイズを確定する（一旦80%にしておく）
                this.Width = (int)(OwnerWidth * 0.8);
                this.Height = (int)(this.Height * (float)((float)this.Width / (float)NowWidth));

                // QR読取り画面の位置を確定する
                this.Top = (OwnerHeight - this.Height) / 2;
                this.Left = (OwnerWidth - this.Width) / 2;
            }
            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// その他パーツの位置調整
        /// </summary>
        private void PartsPosition()
        {
            try
            {
                // 補正値
                int Hosei = 10;

                // VidwoImageパーツの位置とサイズ取得
                int VideoTop = this.VideoImageView.Top;
                int VideoLeft = this.VideoImageView.Left;
                int VideoHeight = this.VideoImageView.Height;

                // メッセージ表示の位置調整
                this.LbMessage.Left = VideoLeft;
                this.LbMessage.Top = VideoTop + VideoHeight + Hosei;
            }
            catch
            {
                throw;
            }
        }


        //--------------------------------------------------
        // カメラ処理
        //--------------------------------------------------
        /// <summary>
        /// カメラのデバイス初期化
        /// </summary>
        private bool InitVideoDevice()
        {
            try
            {
                // デバイス一覧取得
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // 使えるデバイスチェック
                if (videoDevices.Count == 0)
                {
                    // 使えるデバイス無し
                    MessageBox.Show(QRFormMessage.QR_0001);

                    // カメラデバイスの初期化失敗
                    return false;
                }
                else
                {
                    if (VideoSource == null)
                    {
                        // 一旦最初の１つを使用することとする
                        VideoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);

                        // フレームごとに呼ばれるイベントに登録
                        VideoSource.NewFrame += new NewFrameEventHandler(VideoRendering);
                    }

                    // 一旦ストップ処理を行う
                    VideoCaptureStop();

                    // QR読取り初期設定
                    QRCordRead();
                }
            }
            catch
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// カメラデバイスの画像取得開始
        /// </summary>
        private void VideoCaptureStart()
        {
            try
            {
                VideoSource.Start();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カメラデバイスの画像取得終了
        /// </summary>
        private void VideoCaptureStop()
        {
            try
            {
                if (VideoSource != null)
                {
                    if (VideoSource.IsRunning) VideoSource.Stop();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カメラキャプチャフレーム毎の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void VideoRendering(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap img = (Bitmap)eventArgs.Frame.Clone();
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                VideoImageView.Image = img;
            }
            catch
            {
                throw;
            }
        }


        //--------------------------------------------------
        // QRコード読取り処理
        //--------------------------------------------------
        /// <summary>
        /// QR読取り初期設定
        /// </summary>
        private void QRCordRead()
        {
            Reader = new BarcodeReader
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    PossibleFormats = new[] { BarcodeFormat.QR_CODE }
                }
            };
        }
        /// <summary>
        /// QRコードのデコード処理
        /// </summary>
        /// <param name="picture">画像データ</param>
        /// <returns>デコード結果</returns>
        public string Decode(Image picture)
        {
            string ret = null;

            try
            {
                //--------------------------------------------------
                // デフォルト読込（精度低）
                //--------------------------------------------------
                Result result = Reader.Decode((Bitmap)picture);
                if (result != null)
                {
                    ret = result.ToString().Trim();
                    return ret;
                }


                //--------------------------------------------------
                // 標準で読めない場合、読み込んだ画像データを加工する
                //--------------------------------------------------
                List<Image> BinarizationPicture = Binarization((Bitmap)picture);


                if (BinarizationPicture != null)
                {
                    //--------------------------------------------------
                    // 読み込んだ画像データをZXingのQRリーダーへ渡す
                    //--------------------------------------------------
                    foreach (Image img in BinarizationPicture)
                    {
                        //QRCodeをデコード
                        result = Reader.Decode((Bitmap)img);

                        //--------------------------------------------------
                        // 結果を返す
                        //--------------------------------------------------
                        if (result != null)
                        {
                            ret = result.ToString().Trim();
                            break;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// ２値化
        /// </summary>
        /// <param name="picture">Image画像データ</param>
        /// <returns>
        ///     成功時：Imageデータ
        ///     失敗時：null
        /// </returns>
        public List<Image> Binarization(Image picture)
        {
            List<Image> img = new List<Image>();

            try
            {
                //元画像（Image）データをMatデータにする。
                Mat Moto = new Mat();
                Moto = BitmapConverter.ToMat((Bitmap)picture);

                //グレースケール
                Mat Gray = new Mat();
                Cv2.CvtColor(Moto, Gray, ColorConversionCodes.BGRA2GRAY);

                //2値化
                Mat Binari = Gray.Threshold(0.0, 255.0, ThresholdTypes.Binary | ThresholdTypes.Otsu);

                //輪郭検出
                OpenCvSharp.Point[][] edgesArray = Binari.Clone().FindContoursAsArray(RetrievalModes.List, ContourApproximationModes.ApproxSimple, new OpenCvSharp.Point(0, 0));

                //輪郭ごとに処理を加える
                foreach (OpenCvSharp.Point[] item1 in edgesArray)
                {
                    //直線近似にする
                    OpenCvSharp.Point[] normalizedEdges = Cv2.ApproxPolyDP(item1, 10, true);

                    //近似結果から四角のみを対象
                    if (normalizedEdges.Count() == 4)
                    {
                        //輪郭が内接する四角形を作り、長辺に合わせて正方形にしておく
                        Rect rect = Cv2.BoundingRect(normalizedEdges);
                        if (rect.Width < rect.Height) rect.Width = rect.Height;
                        else if (rect.Height < rect.Width) rect.Height = rect.Width;

                        //四角形のサイズが一定の範囲以外は無視する
                        if ((Moto.Width * 0.1) < rect.Width && (Moto.Width * 0.6) > rect.Width
                            && (Moto.Width * 0.1) < rect.Height && (Moto.Width * 0.6) > rect.Height)
                        {
                            //見つけた輪郭を、上記にて作った正方形に補正するための行列を作り、元画像に補正をかける。
                            //補正準備（補正元の輪郭）
                            List<Point2f> srcEdges = new List<Point2f>();
                            foreach (OpenCvSharp.Point edge in normalizedEdges) srcEdges.Add(new Point2f(edge.X, edge.Y));
                            srcEdges.Add(new Point2f(normalizedEdges[0].X, normalizedEdges[0].Y));

                            //補正準備（補正先の輪郭）
                            List<Point2f> dstEdges = new List<Point2f>();
                            dstEdges.Add(new Point2f(rect.X, rect.Y));
                            dstEdges.Add(new Point2f(rect.X + rect.Width, rect.Y));
                            dstEdges.Add(new Point2f(rect.X + rect.Width, rect.Y + rect.Height));
                            dstEdges.Add(new Point2f(rect.X, rect.Y + rect.Height));
                            dstEdges.Add(new Point2f(rect.X, rect.Y));

                            //変換行列の作成
                            Mat t = Cv2.GetPerspectiveTransform(srcEdges, dstEdges);

                            //元画像に補正をかける
                            Mat mat = Gray;
                            mat = mat.WarpPerspective(t, new OpenCvSharp.Size(mat.Width, mat.Height));

                            //画像をリストへ追加
                            img.Add(BitmapConverter.ToBitmap(mat));
                        }
                    }
                }

                if (img.Count == 0) img = null;
            }
            catch (Exception ex)
            {
                img = null;
                throw ex;
            }

            return img;
        }


        //--------------------------------------------------
        // フォームからのアクション
        //--------------------------------------------------
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        private void BtClose_Click(object sender, EventArgs e)
        {
            try
            {
                // フォームを閉じる
                this.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// タイマーの間隔毎に呼ばれる
        /// </summary>
        private void TimerWait_Tick(object sender, EventArgs e)
        {
            // 処理中はタイマー停止させる
            TimerWait.Stop();

            // カメラから画像を取得できれば処理
            if(VideoImageView.Image != null)
            {
                // カメラ画像からQRコード認識、デコード
                string data = Decode(VideoImageView.Image);

                // デコード成功の場合
                if (data != null)
                {
                    // デコード結果をクラスメンバ変数へ設定
                    this.ReturnValue = data;
                    // カメラの画像取得を停止
                    VideoCaptureStop();
                    // ウィンドウクローズ
                    this.Close();
                    // タイマー毎の処理終了（タイマーは再開させないこと）
                    return;
                }
            }

            // 処理後QR認識出来ない場合、タイマー再開
            TimerWait.Start();
        }

        /// <summary>
        /// フォームのロード時
        /// </summary>
        private void QRReadForm_Load(object sender, EventArgs e)
        {
            try
            {
                // フォームの初期設定
                FormSizePosition();

                // その他パーツの位置調整
                PartsPosition();

                // カメラのデバイス初期化
                if (InitVideoDevice())
                {
                    // カメラデバイスの画像取得開始
                    VideoCaptureStart();

                    // QR読取りタイマースタート
                    TimerWait.Start();
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                this.Close();
            }
        }
    }
}
