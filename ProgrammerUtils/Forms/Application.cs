﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ProgrammerUtils.UserControls;

namespace ProgrammerUtils
{
    public partial class Application : Form
    {
        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }

        public static readonly Color NORMAL_ACTIVE_BUTTON_COLOR = Color.FromArgb(255, 43, 84, 134);
        public static readonly Color NORMAL_NOT_ACTIVE_BUTTON_COLOR = Color.FromArgb(255, 73, 87, 103);
        public static readonly Color COPY_BUTTON_COLOR = Color.FromArgb(255, 26, 153, 118);
        public static readonly Color COPY_CLICKED_BUTTON_COLOR = Color.FromArgb(255, 26, 153, 70);

        private static readonly int EXPANDED_NAVIGATION_MENU_SIZE = 250;
        private static readonly int NOT_EXPANDED_NAVIGATION_MENU_SIZE = 38;

        private SortControl _sortControl;
        private CompareControl _compareControl;
        private CountControl _countControl;
        private HTMLControl _htmlControl;
        private GenerateTextControl _generateTextControl;
        private ColorConvertControl _convertColorControl;

        DateTime _lastTime = DateTime.Now;
        readonly Timer _navigationMenuOpenCloseTimer = new Timer(0.15f);
        private bool _navigationTransitioning = false;

        public Application()
        {
            InitializeComponent();

            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Init();
            InitNavigationBar();
        }
        private void Init()
        {
            FrameTimer.Start();

            _sortControl = new SortControl();
            _compareControl = new CompareControl();
            _countControl = new CountControl();
            _htmlControl = new HTMLControl();
            _generateTextControl = new GenerateTextControl();
            _convertColorControl = new ColorConvertControl();

            PlayAreaPanel.Controls.Add(_sortControl);
            PlayAreaPanel.Controls.Add(_compareControl);
            PlayAreaPanel.Controls.Add(_countControl);
            PlayAreaPanel.Controls.Add(_htmlControl);
            PlayAreaPanel.Controls.Add(_generateTextControl);
            PlayAreaPanel.Controls.Add(_convertColorControl);

            _sortControl.Dock = DockStyle.Fill;
            _compareControl.Dock = DockStyle.Fill;
            _countControl.Dock = DockStyle.Fill;
            _htmlControl.Dock = DockStyle.Fill;
            _generateTextControl.Dock = DockStyle.Fill;
            _convertColorControl.Dock = DockStyle.Fill;

            _compareControl.Location = _sortControl.Location;
            _countControl.Location = _sortControl.Location;
            _htmlControl.Location = _sortControl.Location;
            _generateTextControl.Location = _sortControl.Location;
            _convertColorControl.Location = _sortControl.Location;

            HideAllContent();
            _sortControl.Show();
        }

        private void InitNavigationBar()
        {
            navigationMenu.OnNavigationButtonClicked += HeaderNavigationButtonClicked;
            navigationMenu.OnSortClicked += () => { GeneralNavigationButtonClicked(_sortControl, NavigationMenu.NavigationButtons.SORT); };
            navigationMenu.OnCompareClicked += () => { GeneralNavigationButtonClicked(_compareControl, NavigationMenu.NavigationButtons.COMPARE); };
            navigationMenu.OnCountClicked += () => { GeneralNavigationButtonClicked(_countControl, NavigationMenu.NavigationButtons.COUNT); };
            navigationMenu.OnHTMLClicked += () => { GeneralNavigationButtonClicked(_htmlControl, NavigationMenu.NavigationButtons.HTML); };
            navigationMenu.OnGenerateTextClicked += () => { GeneralNavigationButtonClicked(_generateTextControl, NavigationMenu.NavigationButtons.GENERATE_TEXT); };
            navigationMenu.OnConvertColorClicked += () => { GeneralNavigationButtonClicked(_convertColorControl, NavigationMenu.NavigationButtons.CONVERT_COLOR); };
        }

        private void GeneralNavigationButtonClicked(Control control, NavigationMenu.NavigationButtons button)
        {
            //Speeds up performance.
            if (button != NavigationMenu.NavigationButtons.COUNT)
                _countControl.ClearData();

            HideAllContent();
            control.Show();
            navigationMenu.SelectNavigationButton(button);
        }

        private void HideAllContent()
        {
            _sortControl.Hide();
            _compareControl.Hide();
            _countControl.Hide();
            _htmlControl.Hide();
            _generateTextControl.Hide();
        }

        private bool NavigationMenuTick(float delta)
        {
            if (_navigationTransitioning)
            {
                _navigationMenuOpenCloseTimer.Time += delta;

                TableLayoutColumnStyleCollection columns = MainTableLayout.ColumnStyles;
                float ratio = navigationMenu.Expanded ? Math.Min(_navigationMenuOpenCloseTimer.Ratio(), 1) : Math.Max(_navigationMenuOpenCloseTimer.InverseRatio(), 0);

                int deltaSize = (int)(((EXPANDED_NAVIGATION_MENU_SIZE - NOT_EXPANDED_NAVIGATION_MENU_SIZE) * ratio) + NOT_EXPANDED_NAVIGATION_MENU_SIZE);

                navigationMenu.ChangeImageLeftMargin(ratio);
                columns[0].Width = deltaSize;

                if (_navigationMenuOpenCloseTimer.Expired())
                {
                    _navigationMenuOpenCloseTimer.Reset();
                    navigationMenu.DoneTransition();
                    _navigationTransitioning = false;
                }
            }
            return _navigationTransitioning;
        }

        private void HeaderNavigationButtonClicked()
        {
            _navigationTransitioning = true;
            navigationMenu.StartTransitioning();
        }


        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            long elapsedTicks = now.Ticks - _lastTime.Ticks;
            _lastTime = now;

            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            float secondsPassed = (float)elapsedSpan.TotalSeconds;

            if (NavigationMenuTick(secondsPassed))
                Invalidate();
        }

        #region Copy methods

        public static void Copy(Button button, Label label, System.Windows.Forms.Timer copyTimer)
        {
            button.BackColor = COPY_CLICKED_BUTTON_COLOR;
            label.Text = "Copied!";
            copyTimer.Stop();
            copyTimer.Start();
        }

        public static void CopyTimer_Tick(Label label, System.Windows.Forms.Timer copyTimer, Button copyButton, params Button[] copyButtons)
        {
            List<Button> allButtons = copyButtons.Concat(new Button[] { copyButton}).ToList();

            allButtons.ForEach(button => button.BackColor = COPY_BUTTON_COLOR);
            label.Text = string.Empty;
            copyTimer.Stop();
        }

        #endregion
    }
}
