using System;
using System.Drawing;
using System.Windows.Forms;
using MediaToolkit;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			image = null;
			video = null;
			cut = null;
			cutx = 0;
			cuty = 0;
			curFrame = 0;
			history = new System.Collections.Stack();
			this.KeyDown += Form1_KeyDown;
			pictureBox2.MouseWheel += pictureBox2_onMouseWheelRolled;
			Response("Press 'c' to use command. Commands: openpicture, openvideo, size, position, jump, progress. help [command] to get tips.");
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.C)
			{
				textBox1.Enabled = true;
				textBox1.Focus();
				textBox1.Select();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				textBox1.Enabled = false;
			}
			else if (e.KeyCode == Keys.A)
			{
				if (video == null)
					return;
				int newframe = curFrame - 1;
				if (newframe > 0)
				{
					LoadFrame(newframe);
				}
			}
			else if (e.KeyCode == Keys.D)
			{
				if (video == null)
					return;
				int newframe = curFrame + 1;
				if (newframe < totalFrame)
				{
					LoadFrame(newframe);
				}
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (System.IO.File.Exists("temp.jpg"))
			{
				image.Dispose();
				System.IO.File.Delete("temp.jpg");
			}
		}
		
		private void trackBar1_Scroll(object sender, EventArgs e)
		{// width
			label4.Text = trackBar1.Value.ToString() + "%";
			if (image != null)
			{
				ShowCutImage();
			}
		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{// height
			label5.Text = trackBar2.Value.ToString() + "%";
			if (image != null)
			{
				ShowCutImage();
			}
		}

		private void trackBar3_MouseUp(object sender, MouseEventArgs e)
		{// progress
			label6.Text = trackBar3.Value.ToString() + "%";
			if (video != null)
			{
				double progress = 0.01 * trackBar3.Value;
				ChangeProgress(progress);
			}
		}

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (image != null)
			{
				if (grid)
				{
					int x = e.X;
					int y = e.Y;
					int gridheight = (int)(image.Height * trackBar2.Value * 0.01);
					int gridwidth = (int)(image.Width * trackBar1.Value * 0.01);
					int vertc_pos = y / gridheight;
					int horiz_pos = x / gridwidth;
					cutx = horiz_pos * gridwidth + gridwidth / 2;
					cuty = vertc_pos * gridheight + gridheight / 2;
					ShowCutImage();
					ShowGrid();
				}
				else
				{
					int[] pix = GetImgPixelLoc(e.X, e.Y);
					cutx = pix[0];
					cuty = pix[1];
					ShowCutImage();
				}
			}
		}

		private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
		{
			if (cut != null)
			{
				int pointsize = Math.Max(1, (int)(0.005 * Math.Min(image.Width, image.Height)));
				if (e.Button == MouseButtons.Left)
				{// mark
					int x = e.X;
					int y = e.Y;
					int[] point = GetCutPixelLoc(x, y);
					if (point == null)
					{
						return;
					}
					for (int i = point[0] - pointsize / 2; i < point[0] + pointsize / 2 + 1; i++)
					{
						if (i >= 0 && i < image.Width)
						{
							for (int j = point[1] - pointsize / 2; j < point[1] + pointsize / 2 + 1; j++)
							{
								if (j >= 0 && j < image.Height)
								{
									image.SetPixel(i, j, Color.Red);
								}
							}
						}
					}
					history.Push(new int[2] { point[0], point[1] });
				}
				else if(e.Button==MouseButtons.Right)
				{
					if (history.Count != 0)
					{
						int[] point = (int[])history.Pop();
						for (int i = point[0] - pointsize / 2; i < point[0] + pointsize / 2 + 1; i++)
						{
							if (i >= 0 && i < image.Width)
							{
								for (int j = point[1] - pointsize / 2; j < point[1] + pointsize / 2 + 1; j++)
								{
									if (j >= 0 && j < image.Height)
									{
										image.SetPixel(i, j, original_image.GetPixel(i, j));
									}
								}
							}
						}
					}
					
				}
				pictureBox1.Image = image;
				ShowCutImage();
			}
		}

		private void pictureBox2_onMouseWheelRolled(object sender, MouseEventArgs e)
		{
			int newwp = trackBar1.Value - e.Delta / 90;
			int newhp = trackBar2.Value - e.Delta / 90;
			if (newwp < 1)
			{
				trackBar1.Value = 1;
			}
			else if(newwp > 100)
			{
				trackBar1.Value = 100;
			}
			else
			{
				trackBar1.Value = newwp;
			}
			if (newhp < 1)
			{
				trackBar2.Value = 1;
			}
			else if (newhp > 100)
			{
				trackBar2.Value = 100;
			}
			else
			{
				trackBar2.Value = newhp;
			}
			label4.Text = trackBar1.Value.ToString() + "%";
			label5.Text = trackBar2.Value.ToString() + "%";
			if (image != null)
			{
				ShowCutImage();
			}
			if (grid)
			{
				ShowGrid();
			}
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{// grid
			if (!grid)
			{
				grid = true;
				pictureBox3.Image = Resource.gridon;
				ShowGrid();
				ShowCutImage();
			}
			else
			{
				grid = false;
				pictureBox3.Image = Resource.gridoff;
				ShowCutImage();
			}
		}
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{// command
			if (e.KeyCode == Keys.Enter)
			{
				string command = textBox1.Text;
				string sub = command.Substring(command.IndexOf(' ') + 1);
				cmdSearchIndex = 0;
				if (command.StartsWith("help "))
				{
					textBox1.Text = "";
					switch (sub)
					{
						case "openpicture":
							Response("openpicture [path]. To open a picture.");
							break;
						case "openvideo":
							Response("openvideo [path]. To open a video.");
							break;
						case "size":
							Response("size [width] [height] (from 1 to 100).");
							break;
						case "position":
							Response("position [x] [y] (from 0 to image size).");
							break;
						case "jump":
							Response("jump [frame] (from 0 to total frame).");
							break;
						case "progress":
							Response("progress [progress] (from 0 to 100).");
							break;
						default:
							Response("Commands: openpicture, openvideo, size, position, jump, progress. help [command] to get tips.");
							break;
					}
					return;
				}
				if (command.StartsWith("openpicture "))
				{
					try
					{
						LoadImage(sub);
						textBox1.Text = "";
						Response("Opened: " + sub + ".");
					}
					catch (ArgumentException)
					{
						Response("Cannot find: " + sub + ".");
					}
					catch (OutOfMemoryException)
					{
						Response("Should use openvideo to open a video file.");
					}
					return;
				}
				if (command.StartsWith("openvideo "))
				{
					try
					{
						LoadVideo(sub);
						LoadFrame(0);
						textBox1.Text = "";
						Response("Opened: " + sub + ".");
					}
					catch (ArgumentException)
					{
						Response("Cannot find: " + sub + ".");
					}
					catch (System.IO.FileNotFoundException)
					{
						Response("Should use openpicture to open a picture file.");
					}
					return;
				}
				if (command.StartsWith("jump "))
				{
					try
					{
						int frame = int.Parse(sub);
						if (frame <= -1 || frame > maxFrame)
						{
							Response("frame exceeded or smaller than 0");
							return;
						}
						LoadFrame(frame);
						textBox1.Text = "";
					}
					catch (Exception)
					{
						Response("frame exceeded or smaller than 0");
					}
					return;
				}
				if (command.StartsWith("progress "))
				{
					try
					{
						double progress = 0.01 * double.Parse(sub);
						ChangeProgress(progress);
						textBox1.Text = "";
					}
					catch (Exception)
					{
						Response("Bad Arguments.");
					}
					return;
				}
				if (command.StartsWith("size "))
				{
					if (image != null)
					{
						try
						{
							string[] item = sub.Split(' ');
							double wp = double.Parse(item[0].ToString()) * 0.01;
							double hp = double.Parse(item[1].ToString()) * 0.01;
							textBox1.Text = "";
							if (wp <= 1 && wp > 0 && hp <= 1 && hp > 0)
							{
								trackBar1.Value = (int)(wp * 100);
								trackBar2.Value = (int)(hp * 100);
								label4.Text = ((int)(wp * 100)).ToString() + "%";
								label5.Text = ((int)(hp * 100)).ToString() + "%";
								ShowCutImage();
								Response("Size adjusted.");
							}
						}
						catch (Exception)
						{
							Response("Bad Arguments.");
						}
					}
					else
					{
						Response("No image or video opened.");
					}
					return;
				}
				if (command.StartsWith("position "))
				{
					if (image != null)
					{
						try
						{
							string[] item = sub.Split(' ');
							int x = int.Parse(item[0].ToString());
							int y = int.Parse(item[1].ToString());
							textBox1.Text = "";
							if (x > 0 && x < image.Width && y > 0 && y < image.Height)
							{
								cutx = x;
								cuty = y;
								ShowCutImage();
								Response("Position changed.");
							}
						}
						catch (Exception)
						{
							Response("Bad Arguments.");
						}
					}
					else
					{
						Response("No image or video opened.");
					}
					return;
				}
				Response("Commands: openpicture, openvideo, size, position, jump, progress. help [command] to get tips.");
			}
			else if (e.KeyCode == Keys.Tab)
			{
				string command = textBox1.Text;
				if (command.Length > 0 && !(command.TrimEnd(' ')).Contains(" "))
				{
					string tip = FindNextCmd(textBox1.Text[0]);
					if (tip != null)
					{
						textBox1.Text = tip + " ";
						textBox1.SelectionStart = textBox1.Text.Length;
					}
				}
			}
			else if (e.KeyCode == Keys.Escape)
			{
				textBox1.Enabled = false;
			}
		}

		private string FindNextCmd(char c)
		{
			for(int i=0;i<cmds.Length;i++)
			{
				string guess = cmds[(cmdSearchIndex + i) % cmds.Length];
				if (guess[0] == c) 
				{
					string ret = guess;
					cmdSearchIndex += i + 1;
					cmdSearchIndex %= cmds.Length;
					return ret;
				}
			}
			return null;
		}

		private void ShowRegion(int x, int y)
		{
			Bitmap res = new Bitmap(image);
			int linewidth = Math.Max(1, (int)(0.005 * Math.Min(image.Width, image.Height)));
			int width = (int)(image.Width * trackBar1.Value * 0.01);
			int height = (int)(image.Height * trackBar2.Value * 0.01);
			for (int i = x - width / 2 - linewidth; i < x + width / 2 + linewidth; i++)
			{
				if (i >= 0 && i < res.Width)
				{
					for (int j = y - height / 2 - linewidth; j < y - height / 2; j++)
					{
						if (j >= 0 && j < res.Height)
							res.SetPixel(i, j, Color.Red);
					}
					for (int j = y + height / 2; j < y + height / 2 + linewidth; j++)
					{
						if (j >= 0 && j < res.Height)
							res.SetPixel(i, j, Color.Red);
					}
				}
			}
			for (int i = y - height / 2 - linewidth; i < y + height / 2 + linewidth; i++)
			{
				if (i >= 0 && i < res.Height)
				{
					for (int j = x - width / 2 - linewidth; j < x - width / 2; j++)
					{
						if (j >= 0 && j < res.Width)
							res.SetPixel(j, i, Color.Red);
					}
					for (int j = x + width / 2; j < x + width / 2 + linewidth; j++)
					{
						if (j >= 0 && j < res.Width)
							res.SetPixel(j, i, Color.Red);
					}
				}	
			}

			pictureBox1.Image = res;
		}

		private void ShowGrid()
		{
			Bitmap res = new Bitmap(image);
			int linewidth = Math.Max(1, (int)(0.005 * Math.Min(image.Width, image.Height)));
			int gridheight = (int)(image.Height * trackBar2.Value * 0.01);
			int gridwidth = (int)(image.Width * trackBar1.Value * 0.01);

			for (int i = 0; i < image.Width; i++)
			{
				if (i % gridwidth == 0)
				{
					for (int offset = -linewidth/2; offset < linewidth/2; offset++)
					{
						if (i + offset >= 0 && i + offset < image.Width)
							for (int j = 0; j < image.Height; j++)
								res.SetPixel(i + offset, j, Color.Red);
					}
				}
			}

			for (int i = 0; i < image.Height; i++)
			{
				if (i % gridheight == 0)
				{
					for (int offset = -linewidth / 2; offset < linewidth / 2; offset++)
					{
						if (i + offset >= 0 && i + offset < image.Height)
							for (int j = 0; j < image.Width; j++)
								res.SetPixel(j, i + offset, Color.Red);
					}
				}
			}

			pictureBox1.Image = res;
		}

		private void LoadImage(string path)
		{
			original_image = new Bitmap(path);
			image = new Bitmap(original_image);
			mask = new int[image.Size.Width, image.Size.Height];
			toolStripStatusLabel2.Text = image.Width + "*" + image.Height;
			pictureBox1.Image = image;
			pictureBox2.Image = null;
		}

		private void LoadVideo(string path)
		{
			if (engine == null)
			{
				engine = new Engine();
			}
			video = new MediaToolkit.Model.MediaFile { Filename = path };
			engine.GetMetadata(video);
			totalFrame = (int)(video.Metadata.Duration.TotalSeconds * video.Metadata.VideoData.Fps);
			maxFrame = totalFrame - 1;
		}

		private void LoadFrame(int frame)
		{
			double pos = (double)frame / totalFrame * video.Metadata.Duration.TotalSeconds;
			var options = new MediaToolkit.Options.ConversionOptions { Seek = TimeSpan.FromSeconds(pos) };
			if (image != null)
			{
				image.Dispose();
				System.IO.File.Delete("temp.jpg");
			}
			try
			{
				var outputFile = new MediaToolkit.Model.MediaFile { Filename = "temp.jpg" };
				engine.GetThumbnail(video, outputFile, options);
				LoadImage("temp.jpg");
				toolStripStatusLabel3.Text = frame.ToString() + "/" + maxFrame.ToString();
				curFrame = frame;
				int percent = (int)(100 * (double)frame / maxFrame);
				trackBar3.Value = percent;
				label6.Text = percent.ToString() + "%";
			}
			catch(Exception)
			{
				// TODO: 
			}
		}

		private void ChangeProgress(double progress)
		{
			int frame = (int)(progress * maxFrame);
			LoadFrame(frame);
		}

		private void ShowCutImage()
		{
			if (grid)
			{
				ShowCutImage(cutx, cuty);
				
			}
			else
			{
				ShowCutImage(cutx, cuty);
				ShowRegion(cutx, cuty);
			}
		}

		private void ShowCutImage(int x, int y)
		{
			double wp = trackBar1.Value * 0.01;
			double hp = trackBar2.Value * 0.01;
			int width = (int)(image.Width * wp);
			int height = (int)(image.Height * hp);
			int locx = cutx - width / 2;
			int locy = cuty - height / 2;
			Rectangle rectSrc = new Rectangle(locx, locy, width, height);
			Rectangle rectDst = new Rectangle(0, 0, width, height);
			cut = new Bitmap(rectDst.Width, rectDst.Height);
			Graphics graph = Graphics.FromImage(cut);
			graph.DrawImage(image, rectDst, rectSrc, GraphicsUnit.Pixel);
			pictureBox2.Image = cut;
		}

		private void Response(string rsp)
		{
			toolStripStatusLabel1.Text = rsp;
		}

		private int[] GetImgPixelLoc(int x, int y)
		{
			// return: {xpix, ypix}
			int[] result = new int[2];
			double ratio = image.Width / (double)image.Height;
			if (ratio > imgboxratio)
			{
				double scale = (double)pictureBox1.Width / image.Width;
				// xpix
				result[0] = (int)(x / scale);
				// ypix
				double height = image.Height * scale;
				int blank = (int)(pictureBox1.Height - height) / 2;
				if (y < blank)
				{
					result[1] = 0;
				}
				else if (y > height + scale)
				{
					result[1] = image.Height;
				}
				else
				{
					result[1] = (int)((y - blank) / scale);
				}
			}
			else
			{
				double scale = (double)pictureBox1.Height / image.Height;
				// ypix
				result[1] = (int)(y / scale);
				// xpix
				double width = image.Width * scale;
				int blank = (int)(pictureBox1.Width - width) / 2;
				if (x < blank)
				{
					result[0] = 0;
				}
				else if (x > width + scale)
				{
					result[0] = image.Width;
				}
				else
				{
					result[0] = (int)((x - blank) / scale);
				}
			}
			return result;
		}

		private int[] GetCutPixelLoc(int x, int y)
		{
			int[] res = new int[2];
			if (cut.Width > cut.Height)
			{
				double scale = (double)pictureBox2.Width / cut.Width;
				res[0] = (int)((x / scale) + cutx - cut.Width / 2);
				int blank = (int)((pictureBox2.Height - cut.Height * scale) / 2);
				if (y < blank || y > blank + cut.Height * scale)
				{
					return null;
				}
				res[1] = (int)(cuty - cut.Height / 2 + (y - blank) / scale);
 			}
			else
			{
				double scale = pictureBox2.Height / cut.Height;
				res[1] = (int)((y / scale) + cuty - cut.Height / 2);
				int blank = (int)((pictureBox2.Width - cut.Width * scale) / 2);
				if (x < blank || x > blank + cut.Width * scale)
				{
					return null;
				}
				res[0] = (int)(cutx - cut.Width / 2 + (x - blank) / scale);
			}
			return res;
		}

		private Bitmap image;
		private Bitmap original_image;
		private int[,] mask;
		private Color blank = Color.FromArgb(0);
		private const double imgboxratio = 1.5593;
		private MediaToolkit.Model.MediaFile video;
		private Engine engine;
		private int totalFrame; // 总帧数
		private int maxFrame; // 总帧数 - 1
		private int curFrame;
		private Bitmap cut;
		private int cutx;
		private int cuty;
		private int cmdSearchIndex = 0;
		private string[] cmds = { "openpicture", "openvideo", "size", "position", "jump", "progress", "help" };
		private bool grid = false;
		private System.Collections.Stack history;
	}
}
