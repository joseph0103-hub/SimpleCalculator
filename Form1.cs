using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class frmCalculator : Form
    {
        private string currentInput = string.Empty;
        private int firstOperand = 0;
        private string currentOperator = string.Empty;
        private bool isWaitingForSecondOperand = false;
        private bool lastActionWasEquals = false;

        public frmCalculator()
        {
            InitializeComponent();
            WireEvents();
            UpdateDisplays();
        }

        private void WireEvents()
        {
            btnNum0.Click += NumberButton_Click;
            btnNum1.Click += NumberButton_Click;
            btnNum2.Click += NumberButton_Click;
            btnNum3.Click += NumberButton_Click;
            btnNum4.Click += NumberButton_Click;
            btnNum5.Click += NumberButton_Click;
            btnNum6.Click += NumberButton_Click;
            btnNum7.Click += NumberButton_Click;
            btnNum8.Click += NumberButton_Click;
            btnNum9.Click += NumberButton_Click;

            btnOpAdd.Click += AddButton_Click;
            btnOpEql.Click += EqualButton_Click;

            btnEditC.Click += ClearAllButton_Click;
        }

        private void NumberButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (lastActionWasEquals && string.IsNullOrEmpty(currentOperator))
            {
                ResetForNewCalculation();
            }

            currentInput += NormalizeDigit(button.Text);
            lastActionWasEquals = false;
            UpdateDisplays();
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            if (!TryGetCurrentInput(out int number))
            {
                MessageBox.Show("먼저 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            firstOperand = number;
            currentOperator = "+";
            isWaitingForSecondOperand = true;
            currentInput = string.Empty;
            lastActionWasEquals = false;
            UpdateDisplays();
        }

        private void EqualButton_Click(object? sender, EventArgs e)
        {
            if (currentOperator != "+" || !isWaitingForSecondOperand)
            {
                MessageBox.Show("과제 1에서는 덧셈만 계산합니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryGetCurrentInput(out int secondOperand))
            {
                MessageBox.Show("두 번째 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int result = firstOperand + secondOperand;

            txtInputWindow.Text = $"{firstOperand} {currentOperator} {secondOperand} = {result}";
            txtOutputWindow.Text = result.ToString();

            currentInput = result.ToString();
            currentOperator = string.Empty;
            isWaitingForSecondOperand = false;
            lastActionWasEquals = true;
        }

        private void ClearAllButton_Click(object? sender, EventArgs e)
        {
            ResetForNewCalculation();
            UpdateDisplays();
        }

        private bool TryGetCurrentInput(out int value)
        {
            return int.TryParse(currentInput, out value);
        }

        private void UpdateDisplays()
        {
            if (string.IsNullOrEmpty(currentOperator))
            {
                txtInputWindow.Text = lastActionWasEquals ? txtInputWindow.Text : string.Empty;
                txtOutputWindow.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;
                return;
            }

            txtInputWindow.Text = $"{firstOperand} {currentOperator}";
            txtOutputWindow.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;
        }

        private void ResetForNewCalculation()
        {
            currentInput = string.Empty;
            firstOperand = 0;
            currentOperator = string.Empty;
            isWaitingForSecondOperand = false;
            lastActionWasEquals = false;
            txtInputWindow.Text = string.Empty;
            txtOutputWindow.Text = "0";
        }

        private static string NormalizeDigit(string text)
        {
            return text switch
            {
                "０" => "0",
                "１" => "1",
                "２" => "2",
                "３" => "3",
                "４" => "4",
                "５" => "5",
                "６" => "6",
                "７" => "7",
                "８" => "8",
                "９" => "9",
                _ => text
            };
        }
    }
}
