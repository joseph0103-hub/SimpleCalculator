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
            ResetForNewCalculation();
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

            btnOpAdd.Click += OperatorButton_Click;
            btnOpSub.Click += OperatorButton_Click;
            btnOpMul.Click += OperatorButton_Click;
            btnOpDiv.Click += OperatorButton_Click;
            btnOpEql.Click += EqualButton_Click;

            btnEditC.Click += ClearAllButton_Click;
            btnEditCE.Click += ClearEntryButton_Click;
            btnEditDel.Click += DeleteButton_Click;
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

            string digit = NormalizeDigit(button.Text);
            if (currentInput == "0")
            {
                currentInput = digit;
            }
            else
            {
                currentInput += digit;
            }

            lastActionWasEquals = false;
            UpdateDisplays();
        }

        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (!TryGetCurrentInput(out int number))
            {
                MessageBox.Show("먼저 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrEmpty(currentOperator) && isWaitingForSecondOperand)
            {
                currentOperator = button.Text;
                UpdateDisplays();
                return;
            }

            firstOperand = number;
            currentOperator = button.Text;
            isWaitingForSecondOperand = true;
            currentInput = string.Empty;
            lastActionWasEquals = false;
            UpdateDisplays();
        }

        private void EqualButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperator) || !isWaitingForSecondOperand)
            {
                MessageBox.Show("먼저 연산자를 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryGetCurrentInput(out int secondOperand))
            {
                MessageBox.Show("두 번째 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryCalculate(firstOperand, secondOperand, currentOperator, out int result, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "계산 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void ClearEntryButton_Click(object? sender, EventArgs e)
        {
            currentInput = string.Empty;
            lastActionWasEquals = false;

            if (string.IsNullOrEmpty(currentOperator))
            {
                txtInputWindow.Text = string.Empty;
            }

            UpdateDisplays();
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (lastActionWasEquals)
            {
                return;
            }

            if (string.IsNullOrEmpty(currentInput))
            {
                UpdateDisplays();
                return;
            }

            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplays();
        }

        private bool TryCalculate(int left, int right, string op, out int result, out string errorMessage)
        {
            result = 0;
            errorMessage = string.Empty;

            switch (op)
            {
                case "+":
                    result = left + right;
                    return true;
                case "-":
                    result = left - right;
                    return true;
                case "×":
                case "*":
                    result = left * right;
                    return true;
                case "÷":
                case "/":
                    if (right == 0)
                    {
                        errorMessage = "0으로 나눌 수 없습니다.";
                        return false;
                    }

                    result = left / right;
                    return true;
                default:
                    errorMessage = "지원하지 않는 연산입니다.";
                    return false;
            }
        }

        private bool TryGetCurrentInput(out int value)
        {
            return int.TryParse(currentInput, out value);
        }

        private void UpdateDisplays()
        {
            if (string.IsNullOrEmpty(currentOperator))
            {
                if (!lastActionWasEquals)
                {
                    txtInputWindow.Text = string.Empty;
                }

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
