using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;

namespace CSharpRoTabControl {
    public class CustomRoTabControl : TabControl {
        bool ShowErrMessage = false;
        public CustomRoTabControl() : base() {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ItemSize = new Size(20, 15);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.ResizeRedraw = true;
            SelectedIndexChanged += new EventHandler(CustomTabControl_SelectedIndexChanged);
            MouseMove += new MouseEventHandler(CustomTabControl_MouseMove);
            MouseLeave += new EventHandler(CustomTabControl_MouseLeave);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
        }

        void CustomTabControl_MouseLeave(object sender, EventArgs e) {
            hOverTab = -1;
            Invalidate();
        }
        int hOverTab = -1;
        void CustomTabControl_MouseMove(object sender, MouseEventArgs e) {
            int oldhOverTab = hOverTab;
            hOverTab = -1;
            for (int i = 0; i < TabCount; i++)
                if (GetTabRect(i).Contains(e.Location))
                    hOverTab = i;
            if (oldhOverTab != hOverTab) Invalidate();
        }

        void CustomTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            Invalidate();
        }


        protected override void OnPaintBackground(PaintEventArgs pevent) {
            if (this.DesignMode == true) {
                LinearGradientBrush backBrush = new LinearGradientBrush(
                    this.Bounds,
                    SystemColors.ControlLightLight,
                    SystemColors.ControlLight,
                    LinearGradientMode.Vertical);
                pevent.Graphics.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            } else {
                this.InvokePaintBackground(this.Parent, pevent);
                this.InvokePaint(this.Parent, pevent);
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (TabPages.Count > 0) {
                this.PaintAllTheTabs(e.Graphics);
                this.PaintTheTabPageBorder(e.Graphics);
                this.PaintTheSelectedTab(e.Graphics);
            }

        }

        private void PaintAllTheTabs(Graphics g) {
            if (this.TabCount > 0) {
                for (int index = 0; index < this.TabCount; index++) {
                    if (index != this.SelectedIndex)
                        this.PaintTab(g, index);
                }
            }
        }

        private void PaintTab(Graphics g, int index) {
            if (index < 0) {
                if (ShowErrMessage) { MessageBox.Show("PaintTab"); }
                index = 0;
            }
            GraphicsPath path = this.GetPath(index);
            this.PaintTabBackground(g, index, path);
            this.PaintTabBorder(g, index, path);
            this.PaintTabText(g, index);
        }
        public Color backColor = Color.LightSteelBlue;
        private void PaintTabBackground(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path) {
            if (index < 0) {
                if (ShowErrMessage) { MessageBox.Show("PaintTabBackground"); }
                index = 0;
            }
            Rectangle rect = this.GetTabRect(index);
            if (index != hOverTab) {
                graph.FillPath(new System.Drawing.SolidBrush(SystemColors.ControlLightLight), path);
            } else {
                System.Drawing.Brush buttonBrush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(
                        rect,
                        TabPageBackColorTopHover,
                        TabPageBackColorBottomHover,
                        LinearGradientMode.Vertical);
                graph.FillPath(buttonBrush, path);
            }
        }

        private void PaintTabBorder(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path) {
            if (index < 0) {
                if (ShowErrMessage) { MessageBox.Show("PaintTabBorder"); }
                index = 0;
            }
            Pen borderPen = new Pen(backColor);
            graph.DrawPath(borderPen, path);
            if (Alignment == TabAlignment.Bottom) {
                graph.DrawLine(new Pen(TabPageBackColorTop), new PointF(path.PathPoints[0].X - 1, path.PathPoints[0].Y), new PointF(path.PathPoints[1].X + 1, path.PathPoints[1].Y));
                graph.DrawLine(new Pen(TabPageBackColorTop), new PointF(path.PathPoints[0].X - 1, path.PathPoints[0].Y + 1), new PointF(path.PathPoints[1].X + 2, path.PathPoints[1].Y + 1));
            }
            // noch weiss machen (links)
            borderPen.Dispose();
        }
        Color foreColor = Color.Black;
        public Color TextColor {
            get { return foreColor; }
            set { foreColor = value; forebrush = new SolidBrush(value); }
        }
        Font boldFont {
            get { return new Font(Font, FontStyle.Bold); }
        }
        public BildPosition picturePosition = BildPosition.behindTheText;
        public BildPosition PicturePosition {
            get { return picturePosition; }
            set { picturePosition = value; }
        }
        SolidBrush forebrush = new SolidBrush(Color.Black);
        System.Drawing.StringFormat format = new System.Drawing.StringFormat();

        private void PaintTabText(System.Drawing.Graphics graph, int index) {
            if (index < 0) {
                if (ShowErrMessage) { MessageBox.Show("PaintTabText"); }
                index = 0;
            }
            Rectangle rect = this.GetTabRect(index);
            Rectangle rect2 = new Rectangle(rect.Left + rect.Height + 2, rect.Top, rect.Width - rect.Height, rect.Height);
            if (index > -1) {
                rect2 = new Rectangle(rect.Left + 8, rect.Top, rect.Width - 6, rect.Height);
            }
            if (TabPages[index].ImageIndex != -1) {
                Point bildPunkt;
                if (PicturePosition == BildPosition.behindTheText) {
                    bildPunkt = new Point(rect.Left + rect.Width - ImageList.ImageSize.Width - 5, (20 - ImageList.ImageSize.Height) / 2 + 1);
                } else {
                    bildPunkt = new Point(rect2.Left, (20 - ImageList.ImageSize.Height) / 2 + 1);
                    rect2.X += ImageList.ImageSize.Width + 5;
                }
                graph.DrawImage(ImageList.Images[TabPages[index].ImageIndex], bildPunkt);
            }
            string tabtext = this.TabPages[index].Text;
            if (index == this.SelectedIndex)
                graph.DrawString(tabtext, boldFont, forebrush, rect2, format);
            else
                graph.DrawString(tabtext, this.Font, forebrush, rect2, format);
        }
        #region Colores
        Color tabPageBorderColor;
        public Color TabPageBorderColor {
            get { return (tabPageBorderColor == Color.Empty ? backColor : tabPageBorderColor); }
            set { tabPageBorderColor = value; }
        }
        Color tabPageBackColorTop;
        public Color TabPageBackColorTop {
            get { return (tabPageBackColorTop == Color.Empty ? SystemColors.ControlLight : tabPageBackColorTop); }
            set { tabPageBackColorTop = value; }

        }
        Color tabPageBackColorBottom;
        public Color TabPageBackColorBottom {
            get { return (tabPageBackColorBottom == Color.Empty ? backColor : tabPageBackColorBottom); }
            set { tabPageBackColorBottom = value; }
        }
        Color tabPageBackColorTopHover;
        public Color TabPageBackColorTopHover {
            get { return (tabPageBackColorTopHover == Color.Empty ? SystemColors.ControlLight : tabPageBackColorTopHover); }
            set { tabPageBackColorTopHover = value; }

        }
        Color tabPageBackColorBottomHover;
        public Color TabPageBackColorBottomHover {
            get { return (tabPageBackColorBottomHover == Color.Empty ? backColor : tabPageBackColorBottomHover); }
            set { tabPageBackColorBottomHover = value; }
        }
        #endregion 
        int maxImageHeight = 13;
        public int MaxImageHeight {
            get { return maxImageHeight; }
            set {
                maxImageHeight = value;
                if (ImageList != null && ImageList.ImageSize.Height > maxImageHeight) {
                    ImageList tmpImages = new ImageList();
                    float verh = (float)ImageList.ImageSize.Width / (float)ImageList.ImageSize.Height;
                    tmpImages.ImageSize = new Size((int)(maxImageHeight * verh), maxImageHeight);
                    for (int i = 0; i < ImageList.Images.Count; i++)
                        tmpImages.Images.Add(ImageList.Images[i]);
                    ImageList = tmpImages;
                }
            }
        }
        public new ImageList ImageList {
            get { return base.ImageList; }
            set {
                if (value.ImageSize.Height > maxImageHeight) {
                    //float verh = (float)value.ImageSize.Width / (float)value.ImageSize.Height;
                    //value.ImageSize = new Size((int)(maxImageHeight * verh), maxImageHeight);
                    ImageList tmpImages = new ImageList();
                    float verh = (float)value.ImageSize.Width / (float)value.ImageSize.Height;
                    tmpImages.ImageSize = new Size((int)(maxImageHeight * verh), maxImageHeight);
                    for (int i = 0; i < value.Images.Count; i++)
                        tmpImages.Images.Add(value.Images[i]);
                    value = tmpImages;
                }
                base.ImageList = value;
            }
        }
        BorderStyles borderStyle = BorderStyles.flat;
        public BorderStyles BorderStyle {
            get { return borderStyle; }
            set { borderStyle = value; }
        }

        private void PaintTheTabPageBorder(Graphics g) {
            if (this.TabCount > 0) {
                Rectangle borderRect = this.TabPages[0].Bounds;
                borderRect.X -= 4;
                borderRect.Y -= 1;
                borderRect.Width += 5;
                borderRect.Height += 2;
                Pen P = new Pen(TabPageBorderColor);
                //borderRect.Inflate(4, 4);
                ControlPaint.DrawBorder(g, borderRect, TabPageBorderColor, ButtonBorderStyle.Solid);
                g.DrawLine(P, borderRect.X, borderRect.Y - 1, borderRect.X + borderRect.Width - 1, borderRect.Y - 1);
                //                borderRect.Inflate(1, 1);
                //                ControlPaint.DrawBorder(g, borderRect, TabPageBorderColor, ButtonBorderStyle.Solid);
                //                borderRect.Inflate(1, 1);
                //                ControlPaint.DrawBorder(g, borderRect, TabPageBackColorTop, ButtonBorderStyle.Solid);
                //                borderRect.Inflate(1, 1);
                //                ControlPaint.DrawBorder(g, borderRect, TabPageBorderColor, ButtonBorderStyle.Outset);
            }
        }
        private void PaintTheSelectedTab(Graphics g) {
            Rectangle selrect;
            int selrectRight = 0;
            GraphicsPath path = this.GetPath(this.SelectedIndex);
            if (this.SelectedIndex >= 0) {
                Rectangle rect = this.GetTabRect(this.SelectedIndex);
                System.Drawing.Brush buttonBrush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(
                        rect,
                        TabPageBackColorTop,
                        TabPageBackColorBottom,
                        LinearGradientMode.Vertical);
                g.FillPath(buttonBrush, path);
                selrect = this.GetTabRect(this.SelectedIndex);
                selrectRight = selrect.Right;
                this.PaintTabBorder(g, this.SelectedIndex, path);
                this.PaintTabText(g, this.SelectedIndex);
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetPath(int index) {
            if (index < 0) {
                if (ShowErrMessage) { MessageBox.Show("GetPath"); }
                index = 0;
            }

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.Reset();

            Rectangle rect = this.GetTabRect(index);
            switch (Alignment) {
                case TabAlignment.Top:
                    if (index == 0) {  // Aligment.Top
                        //this.TabPages[0].Width += 5;
                        //rect.Width += 5;
                        path.AddLine(rect.Left - 4, rect.Bottom + 1, rect.Left + rect.Height - 5, rect.Top + 2);
                        path.AddLine(rect.Left + rect.Height, rect.Top, rect.Right - 3, rect.Top);
                        path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    } else {
                        if (index == this.SelectedIndex) {
                            path.AddLine(rect.Left - 8, rect.Bottom + 1, rect.Left + rect.Height - 9, rect.Top + 2);
                            path.AddLine(rect.Left + rect.Height + 4 - 9, rect.Top, rect.Right - 3, rect.Top);
                            path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                        } else {
                            path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
                            path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
                            path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                            path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                        }

                    }
                    break;
                case TabAlignment.Bottom:
                    if (index == 0) {
                        path.AddLine(rect.Right - 1, rect.Top - 1, rect.Left - 8, rect.Top - 1);
                        path.AddLine(rect.Left + 1, rect.Top - 1, rect.Left + rect.Height, rect.Bottom - 2);
                        path.AddLine(rect.Left + rect.Height + 6, rect.Bottom + 1, rect.Right - 3, rect.Bottom + 1);
                        path.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Right - 1, rect.Top - 1);
                    } else {
                        if (index == this.SelectedIndex) {
                            path.AddLine(rect.Right - 1, rect.Top - 1, rect.Left - 8, rect.Top - 1);
                            path.AddLine(rect.Left - 8, rect.Top - 1, rect.Left + rect.Height - 9, rect.Bottom - 2);
                            path.AddLine(rect.Left + rect.Height + 4 - 7, rect.Bottom + 1, rect.Right - 3, rect.Bottom + 1);
                            path.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Right - 1, rect.Top - 1);
                        } else {
                            path.AddLine(rect.Right - 1, rect.Top - 1, rect.Left, rect.Top - 1);
                            path.AddLine(rect.Left, rect.Top, rect.Left, rect.Top + 8);
                            path.AddLine(rect.Left, rect.Top + 8, rect.Left + 5, rect.Bottom - 1);
                            path.AddLine(rect.Left + 8, rect.Bottom + 1, rect.Right - 1, rect.Bottom + 1);
                            path.AddLine(rect.Right - 1, rect.Bottom - 2, rect.Right - 1, rect.Top - 1);
                        }

                    }
                    break;
            }
            return path;
        }
        public enum BildPosition {
            beforeTheText,
            behindTheText
        }
        public enum BorderStyles {
            flat,
            style3D
        }
    }
}
//beforeTheText