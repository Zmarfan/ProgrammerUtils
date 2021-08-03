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


        private static readonly int EXPANDED_NAVIGATION_MENU_SIZE = 250;
        private static readonly int NOT_EXPANDED_NAVIGATION_MENU_SIZE = 44;

        readonly static Color NORMAL_ACTIVE_BUTTON_COLOR = Color.LightSteelBlue;
        readonly static Color NORMAL_NOT_ACTIVE_BUTTON_COLOR = Color.Gray;
        readonly static Color COPY_BUTTON_COLOR = Color.LightGoldenrodYellow;
        readonly static Color COPY_CLICKED_BUTTON_COLOR = Color.LimeGreen;

        Matcher _matcher;
        HtmlCenter _html;
        GenerateText _generateText;
        Counter _counter;
        HtmlExtraSettings _htmlExtraSettingsWindow;

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

            MatchCombinedShowModeDropdown.SelectedIndex = 0;
            generateParagraphType.SelectedIndex = 0;
            countSortModes.SelectedIndex = 0;

            _matcher = new Matcher(MatchLeftText1,
                MatchLeftText2,
                matchRightText1,
                matchRightText2,
                matchResultCombinedTextBox,
                matchRightText1Label,
                matchRightText2Label,
                matchResultTabCombinedLabel
                );

            SetButtonStatus(matchMatchButton, !matchAutoCompare.Checked);
            DoMatch();    
            
            _html = new HtmlCenter(htmlInputTextbox, htmlOutputTextbox);

            DoHtml();

            _generateText = new GenerateText(generateOutputTextbox, generateSeed);

            _counter = new Counter(
                countWordFrequencyFlowLayoutPanel, 
                countWordDensityFlowLayoutPanel, 
                countUniqueWordsFlowLayoutPanel,
                countInputTextbox, 
                countDetailWords, 
                countDetailUniqueWords, 
                countDetailDifferentWords, 
                countDetailCharacters, 
                countDetailSentences, 
                countDetailParagraphs
                );

            htmlCopyLabel.Text = string.Empty;
            generateCopyLabel.Text = string.Empty;

            htmlTagColorRectangle.BackColorChanged += (s, e) => {
                htmlTagColorRectangle.FlatAppearance.MouseOverBackColor = htmlTagColorRectangle.BackColor;
                htmlTagColorRectangle.FlatAppearance.MouseDownBackColor = htmlTagColorRectangle.BackColor;
            };

            htmlEntityColorRectangle.BackColorChanged += (s, e) => {
                htmlEntityColorRectangle.FlatAppearance.MouseOverBackColor = htmlTagColorRectangle.BackColor;
                htmlEntityColorRectangle.FlatAppearance.MouseDownBackColor = htmlTagColorRectangle.BackColor;
            };
        }

        private void SetButtonStatus(Button button, bool status)
        {
            button.Enabled = status;
            button.BackColor = status ? NORMAL_ACTIVE_BUTTON_COLOR : NORMAL_NOT_ACTIVE_BUTTON_COLOR;
        }

        #region Navigation

        readonly Timer _navigationMenuOpenCloseTimer = new Timer(0.15f);
        private bool _navigationTransitioning = false;

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
                    _navigationTransitioning = false;
                }

                return true;
            }
            return false;
        }

        private void InitNavigationBar()
        {
            navigationMenu.OnNavigationButtonClicked += NavigationButtonClicked;
        }

        private void NavigationButtonClicked()
        {
            _navigationTransitioning = true;
            navigationMenu.ChangeExpansionMode();
        }

        #endregion

        #region Match

        private void DoMatch()
        {
            _matcher.DoMatch(matchCaseSensitive.Checked, MatchRemoveExtraWhiteSpace.Checked, GetCombinedDisplayMode());
        }

        private Matcher.CombinedDisplayMode GetCombinedDisplayMode()
        {
            string current = MatchCombinedShowModeDropdown.Text;
            switch (current)
            {
                case "Every line": return Matcher.CombinedDisplayMode.NEW_LINE;
                case "Every word": return Matcher.CombinedDisplayMode.NEW_WORD;
                default:
                    throw new Exception($"There exist no implementation for this enum type: {current}");
            }
        }

        #region Events

        private void MatchMatchButton_Click(object sender, EventArgs e)
        {
            DoMatch();
        }

        private void MatchAutoCompare_CheckedChanged(object sender, EventArgs e)
        {
            SetButtonStatus(matchMatchButton, !matchAutoCompare.Checked);
            if (matchAutoCompare.Checked)
                DoMatch();
        }

        private void MatchCheckboxChecked(object sender, EventArgs e)
        {
            if (matchAutoCompare.Checked)
                DoMatch();
        }

        private void MatchTextChanged(object sender, EventArgs e)
        {
            if (matchAutoCompare.Checked)
                DoMatch();
        }

        private void MatchClearButton_Click(object sender, EventArgs e)
        {
            MatchLeftText1.Text = string.Empty;
            MatchLeftText2.Text = string.Empty;

            DoMatch();
        }

        private void MatchCombinedShowModeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchAutoCompare.Checked && _matcher != null)
                DoMatch();
        }

        #endregion
        #endregion

        #region HTML
        #region Helper Functions

        private void DoHtml()
        {
            _html.ConvertTextToHTML(
                htmlColorTagsCheckbox.Checked, 
                htmlColorEntitiesCheckbox.Checked,
                htmlColorCustomCheckbox.Checked,
                htmlTagColorRectangle.BackColor, 
                htmlEntityColorRectangle.BackColor,
                htmlCustomColorRectangle.BackColor
                );
        }

        private void ChangeHtmlRaiseLowerText(CheckBox checkBox, int offset)
        {
            Font newFont, oldFont;
            oldFont = htmlInputTextbox.SelectionFont;

            if (!checkBox.Checked)
            {
                newFont = new Font(oldFont.Name, 7.8f, oldFont.Style, oldFont.Unit);
                htmlInputTextbox.SelectionCharOffset = 0;
            }
            else
            {
                newFont = new Font(oldFont.Name, 5.8f, oldFont.Style, oldFont.Unit);
                htmlInputTextbox.SelectionCharOffset = offset;
            }

            htmlInputTextbox.SelectionFont = newFont;
            htmlInputTextbox.Focus();
        }

        private void ChangeColorForEntityOrTag(Button showColorButton)
        {
            if (htmlColorTagPicker.ShowDialog() == DialogResult.OK)
            {
                Color color = htmlColorTagPicker.Color;
                showColorButton.BackColor = color;
                htmlColorHoverTooltip.SetToolTip(showColorButton, $"R{color.R}G{color.G}B{color.B}");

                DoHtml();
            }
        }

        #endregion
        #region Events

        private void HtmlButton_Click(object sender, EventArgs e)
        {
            DoHtml();
        }

        private void HtmlCustomRulesButton_Click(object sender, EventArgs e)
        {
            if (_htmlExtraSettingsWindow == null)
            {
                _htmlExtraSettingsWindow = new HtmlExtraSettings();
                _htmlExtraSettingsWindow.FormClosed += (s, ev) => { _htmlExtraSettingsWindow = null; };
                _htmlExtraSettingsWindow.Show();
            }
        }

        private void HTMLTextStyleButtonChange(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                checkBox.BackColor = Color.AliceBlue;
                checkBox.ForeColor = Color.Blue;
            }
            else
            {
                checkBox.BackColor = Color.Lavender;
                checkBox.ForeColor = Color.FromArgb(255, 10, 13, 20);
            }
        }

        private void HtmlBoldButton_CheckedChanged(object sender, EventArgs e)
        {
            Font newFont, oldFont;
            oldFont = htmlInputTextbox.SelectionFont;
            if (!htmlBoldButton.Checked)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

            htmlInputTextbox.SelectionFont = newFont;
            htmlInputTextbox.Focus();
        }

        private void HtmlItalicButton_CheckedChanged(object sender, EventArgs e)
        {
            Font newFont, oldFont;
            oldFont = htmlInputTextbox.SelectionFont;
            if (!htmlItalicButton.Checked)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

            htmlInputTextbox.SelectionFont = newFont;
            htmlInputTextbox.Focus();
        }

        private void HtmlStrikeThroughButton_CheckedChanged(object sender, EventArgs e)
        {
            Font newFont, oldFont;
            oldFont = htmlInputTextbox.SelectionFont;
            if (!htmlStrikeThroughButton.Checked)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Strikeout);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Strikeout);

            htmlInputTextbox.SelectionFont = newFont;
            htmlInputTextbox.Focus();
        }

        private void HtmlUnderscoreButton_CheckedChanged(object sender, EventArgs e)
        {
            Font newFont, oldFont;
            oldFont = htmlInputTextbox.SelectionFont;
            if (!htmlUnderscoreButton.Checked)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);

            htmlInputTextbox.SelectionFont = newFont;
            htmlInputTextbox.Focus();
        }

        private void HtmlRaisedButton_CheckedChanged(object sender, EventArgs e)
        {
            htmlLoweredButton.Checked = false;
            ChangeHtmlRaiseLowerText(htmlRaisedButton, HtmlCenter.RAISED_OFFSET);
        }

        private void HtmlLoweredButton_CheckedChanged(object sender, EventArgs e)
        {
            htmlRaisedButton.Checked = false;
            ChangeHtmlRaiseLowerText(htmlLoweredButton, HtmlCenter.LOWERED_OFFSET);
        }

        private void HtmlInputTextbox_SelectionChanged(object sender, EventArgs e)
        {
            if (htmlInputTextbox.SelectionLength == 0)
            {
                Font currentFont = htmlInputTextbox.SelectionFont;

                htmlBoldButton.Checked = currentFont.Bold;
                htmlItalicButton.Checked = currentFont.Italic;
                htmlUnderscoreButton.Checked = currentFont.Underline;
                htmlStrikeThroughButton.Checked = currentFont.Strikeout;
                htmlRaisedButton.Checked = htmlInputTextbox.SelectionCharOffset == HtmlCenter.RAISED_OFFSET;
                htmlLoweredButton.Checked = htmlInputTextbox.SelectionCharOffset == HtmlCenter.LOWERED_OFFSET;

                HTMLTextStyleButtonChange(htmlBoldButton, null);
                HTMLTextStyleButtonChange(htmlItalicButton, null);
                HTMLTextStyleButtonChange(htmlUnderscoreButton, null);
                HTMLTextStyleButtonChange(htmlStrikeThroughButton, null);
                HTMLTextStyleButtonChange(htmlRaisedButton, null);
                HTMLTextStyleButtonChange(htmlLoweredButton, null);
            }
        }

        private void HtmlChooseColorButton_Click(object sender, EventArgs e)
        {
            ChangeColorForEntityOrTag(htmlTagColorRectangle);
        }

        private void HtmlChangeEntityColorButton_Click(object sender, EventArgs e)
        {
            ChangeColorForEntityOrTag(htmlEntityColorRectangle);
        }

        private void HtmlChangeCustomColorButton_Click(object sender, EventArgs e)
        {
            ChangeColorForEntityOrTag(htmlCustomColorRectangle);
        }

        private void HtmlCopyButton_Click(object sender, EventArgs e)
        {
            Copy(htmlCopyButton, htmlCopyLabel);
            if (htmlOutputTextbox.Text.Length > 0)
                Clipboard.SetText(htmlOutputTextbox.Text);
        }

        private void HtmlClearButton_Click(object sender, EventArgs e)
        {
            htmlInputTextbox.Text = "";
            htmlOutputTextbox.Text = "";
        }

        private void HtmlOpenAllTags_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.html.am/reference/html-special-characters.cfm");
        }

        private void HtmlColorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            DoHtml();
        }

        #endregion
        #endregion

        #region Generate Text
        #region Helper Methods

        private void DoGenerateText(bool customSeed)
        {
            if (_generateText != null)
                _generateText.GenerateRandomWords((int)generateNumberOfWords.Value, GetParagraphType(), customSeed, generateParagraphSizeSlider.Value);
        }

        private GenerateText.ParagraphType GetParagraphType()
        {
            string current = generateParagraphType.Text;
            switch (current)
            {
                case ("Blank row"): return GenerateText.ParagraphType.BLANK_ROW;
                case ("Indent"): return GenerateText.ParagraphType.INDENT;
                case ("No paragraphs"): return GenerateText.ParagraphType.NO_PARAGRAPHS;
                default: throw new Exception($"There exist no implementation for this paragraph type: {current}");
            }
        }

        private void EnableSeed(bool enable)
        {
            generateSeed.Enabled = enable;
            generateSeedLabel.Enabled = enable;

        }

        #endregion
        #region Events

        private void GenerateGenerateButton_Click(object sender, EventArgs e)
        {
            DoGenerateText(generateCustomSeed.Checked);
        }

        private void GenerateCopyButton_Click(object sender, EventArgs e)
        {
            Copy(generateCopyButton, generateCopyLabel);
            if (generateOutputTextbox.Text.Length > 0)
                Clipboard.SetText(generateOutputTextbox.Text);
        }

        private void GenerateClearButton_Click(object sender, EventArgs e)
        {
            generateOutputTextbox.Text = string.Empty;
        }

        private void GenerateCustomSeed_CheckedChanged(object sender, EventArgs e)
        {
            EnableSeed(generateCustomSeed.Checked);
        }

        private void GenerateParagraphType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoGenerateText(true);
        }

        private void GenerateParagraphSizeSlider_MouseUp(object sender, MouseEventArgs e)
        {
            DoGenerateText(true);
        }

        #endregion
        #endregion

        #region Count
        #region Helper Methods

        private void DoCount()
        {
            if (_counter != null)
                _counter.Execute(GetCurrentSortMode(), countCaseSensitive.Checked);
        }

        private Counter.SortMode GetCurrentSortMode()
        {
            switch (countSortModes.Text)
            {
                case ("Alphabetical"): return Counter.SortMode.ALPHABETICAL;
                case ("Value"): return Counter.SortMode.AMOUNT;
                default: throw new Exception($"There exists no implementation for the sortMode {countSortModes.Text}");
            }
        }

        #endregion
        #region Events

        private void CountButton_Click(object sender, EventArgs e)
        {
            DoCount();
        }

        private void CountClearButton_Click(object sender, EventArgs e)
        {
            countInputTextbox.Text = string.Empty;
            DoCount();
        }

        private void CountSortModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoCount();
        }

        private void CountCaseSensitive_CheckedChanged(object sender, EventArgs e)
        {
            DoCount();
        }

        #endregion
        #endregion

        #region Copy Timer

        private void Copy(Button button, Label label)
        {
            button.BackColor = COPY_CLICKED_BUTTON_COLOR;
            label.Text = "Copied!";
            CopyTimer.Stop();
            CopyTimer.Start();
        }

        private void CopyTimer_Tick(object sender, EventArgs e)
        {
            htmlCopyButton.BackColor = COPY_BUTTON_COLOR;
            generateCopyButton.BackColor = COPY_BUTTON_COLOR;
            htmlCopyLabel.Text = string.Empty;
            generateCopyLabel.Text = string.Empty;
            CopyTimer.Stop();
        }
        #endregion

        DateTime _lastTime = DateTime.Now;

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
    }
}
