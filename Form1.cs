using System;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class frmCalculator : Form
    {
        // 현재 입력 중인 숫자를 문자열 형태로 저장
        private string currentInput = string.Empty;
        private decimal firstOperand = 0m;
        private string currentOperator = string.Empty;

        // 두 번째 숫자 입력 대기 상태 여부
        private bool isWaitingForSecondOperand = false;

        // 마지막 동작이 '=' 버튼인지 여부
        private bool lastActionWasEquals = false;

        // 계산 기록 표시용 컨트롤
        private ListBox? lstHistory;
        private Button? btnHistoryReset;

        public frmCalculator()
        {
            InitializeComponent();

            // 버튼 이벤트 연결
            WireEvents();

            // 키보드 입력을 폼에서 먼저 받도록 설정
            KeyPreview = true;
            KeyDown += frmCalculator_KeyDown;

            // 계산 기록 영역 동적 생성
            SetupTask4HistoryControls();

            // 초기 상태로 리셋
            ResetForNewCalculation();

            // 화면 초기화
            UpdateDisplays();
        }

        // 모든 버튼 이벤트를 연결하는 함수
        private void WireEvents()
        {
            // 숫자 버튼 이벤트 연결
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

            // 연산자 버튼 이벤트 연결
            btnOpAdd.Click += OperatorButton_Click;
            btnOpSub.Click += OperatorButton_Click;
            btnOpMul.Click += OperatorButton_Click;
            btnOpDiv.Click += OperatorButton_Click;

            // '=' 버튼 이벤트
            btnOpEql.Click += EqualButton_Click;

            // 기능 버튼 이벤트
            btnEditC.Click += ClearAllButton_Click;
            btnEditCE.Click += ClearEntryButton_Click;
            btnEditDel.Click += DeleteButton_Click;

            btnFuncPlus.Click += PlusMinusButton_Click;
            btnFuncDot.Click += DotButton_Click;
        }

        // 계산 기록 표시용 ListBox와 초기화 버튼 생성
        private void SetupTask4HistoryControls()
        {
            lstHistory = new ListBox();
            lstHistory.Name = "lstHistory";
            lstHistory.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstHistory.Location = new Point(490, 92);
            lstHistory.Size = new Size(260, 304);

            btnHistoryReset = new Button();
            btnHistoryReset.Name = "btnHistoryReset";
            btnHistoryReset.Text = "Reset History";
            btnHistoryReset.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnHistoryReset.Location = new Point(490, 415);
            btnHistoryReset.Size = new Size(260, 44);
            btnHistoryReset.BackColor = Color.FromArgb(224, 224, 224);
            btnHistoryReset.Click += btnHistoryReset_Click;

            Controls.Add(lstHistory);
            Controls.Add(btnHistoryReset);

            ClientSize = new Size(780, 500);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        // 숫자 버튼 클릭 시 처리
        private void NumberButton_Click(object? sender, EventArgs e)
        {
            // 버튼 타입 체크
            if (sender is not Button button)
            {
                return;
            }

            // '=' 이후 새로운 입력이면 초기화
            if (lastActionWasEquals && string.IsNullOrEmpty(currentOperator))
            {
                ResetForNewCalculation();
            }

            // 버튼 텍스트를 숫자로 변환
            string digit = NormalizeDigit(button.Text);

            // 기존 값이 0이면 덮어쓰기
            if (currentInput == "0")
            {
                currentInput = digit;
            }
            else if (currentInput == "-0")
            {
                currentInput = "-" + digit;
            }
            else
            {
                currentInput += digit;
            }

            lastActionWasEquals = false;
            UpdateDisplays();
        }

        private void DotButton_Click(object? sender, EventArgs e)
        {
            if (lastActionWasEquals && string.IsNullOrEmpty(currentOperator))
            {
                ResetForNewCalculation();
            }

            if (string.IsNullOrEmpty(currentInput))
            {
                currentInput = "0.";
            }
            else if (currentInput == "-")
            {
                currentInput = "-0.";
            }
            else if (!currentInput.Contains('.'))
            {
                currentInput += ".";
            }

            lastActionWasEquals = false;
            UpdateDisplays();
        }

        private void PlusMinusButton_Click(object? sender, EventArgs e)
        {
            if (lastActionWasEquals && string.IsNullOrEmpty(currentOperator))
            {
                currentInput = FormatDecimal(ParseOrZero(currentInput) * -1m);
                txtInputWindow.Text = string.Empty;
                txtOutputWindow.Text = currentInput;
                lastActionWasEquals = false;
                return;
            }

            if (string.IsNullOrEmpty(currentInput))
            {
                currentInput = "-";
            }
            else if (currentInput.StartsWith("-"))
            {
                currentInput = currentInput.Substring(1);
            }
            else
            {
                currentInput = "-" + currentInput;
            }

            UpdateDisplays();
        }

        // 연산자 버튼 클릭 시 처리
        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (!TryGetCurrentInput(out decimal number))
            {
                MessageBox.Show("먼저 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 이미 연산자가 선택된 상태에서 다시 선택한 경우 (연산자만 변경)
            if (!string.IsNullOrEmpty(currentOperator) && isWaitingForSecondOperand)
            {
                currentOperator = button.Text;
                UpdateDisplays();
                return;
            }

            // 첫 번째 값 저장
            firstOperand = number;

            // 연산자 저장
            currentOperator = button.Text;

            // 두 번째 값 입력 대기 상태
            isWaitingForSecondOperand = true;

            // 다음 입력을 위해 초기화
            currentInput = string.Empty;
            lastActionWasEquals = false;

            UpdateDisplays();
        }

        // '=' 버튼 클릭 시 계산 수행
        private void EqualButton_Click(object? sender, EventArgs e)
        {
            // 연산자가 없는 경우
            if (string.IsNullOrEmpty(currentOperator) || !isWaitingForSecondOperand)
            {
                MessageBox.Show("먼저 연산자를 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryGetCurrentInput(out decimal secondOperand))
            {
                MessageBox.Show("두 번째 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryCalculate(firstOperand, secondOperand, currentOperator, out decimal result, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "계산 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formattedExpression = $"{FormatDecimal(firstOperand)} {currentOperator} {FormatDecimal(secondOperand)} = {FormatDecimal(result)}";
            string formattedResult = FormatDecimal(result);

            txtInputWindow.Text = formattedExpression;
            txtOutputWindow.Text = formattedResult;

            // 계산 기록 추가
            lstHistory?.Items.Add(formattedExpression);

            currentInput = formattedResult;
            currentOperator = string.Empty;
            isWaitingForSecondOperand = false;
            lastActionWasEquals = true;
        }

        // 전체 초기화 (C 버튼)
        private void ClearAllButton_Click(object? sender, EventArgs e)
        {
            ResetForNewCalculation();
            UpdateDisplays();
        }

        // 현재 입력값만 초기화 (CE 버튼)
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

        // 한 글자 삭제 (Del 버튼)
        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            // '=' 이후에는 삭제 불가
            if (lastActionWasEquals)
            {
                return;
            }

            if (string.IsNullOrEmpty(currentInput))
            {
                UpdateDisplays();
                return;
            }

            // 마지막 문자 제거
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplays();
        }

        // 키보드 입력 지원
        private void frmCalculator_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift)
            {
                AppendDigit(((int)e.KeyCode - (int)Keys.D0).ToString());
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                AppendDigit(((int)e.KeyCode - (int)Keys.NumPad0).ToString());
                e.SuppressKeyPress = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Add:
                case Keys.Oemplus when e.Shift:
                    ApplyOperator("+");
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Subtract:
                case Keys.OemMinus:
                    ApplyOperator("-");
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Multiply:
                    ApplyOperator("×");
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Divide:
                case Keys.OemQuestion:
                    ApplyOperator("÷");
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Decimal:
                case Keys.OemPeriod:
                    DotButton_Click(btnFuncDot, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Enter:
                case Keys.Oemplus when !e.Shift:
                    EqualButton_Click(btnOpEql, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Back:
                    DeleteButton_Click(btnEditDel, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Escape:
                    ClearAllButton_Click(btnEditC, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        // 키보드 숫자 입력 시 공통 처리
        private void AppendDigit(string digit)
        {
            if (lastActionWasEquals && string.IsNullOrEmpty(currentOperator))
            {
                ResetForNewCalculation();
            }

            if (currentInput == "0")
            {
                currentInput = digit;
            }
            else if (currentInput == "-0")
            {
                currentInput = "-" + digit;
            }
            else
            {
                currentInput += digit;
            }

            lastActionWasEquals = false;
            UpdateDisplays();
        }

        // 키보드 연산자 입력 시 공통 처리
        private void ApplyOperator(string op)
        {
            Button fakeButton = new Button();
            fakeButton.Text = op;
            OperatorButton_Click(fakeButton, EventArgs.Empty);
        }

        // 계산 기록 초기화
        private void btnHistoryReset_Click(object? sender, EventArgs e)
        {
            lstHistory?.Items.Clear();
        }

        // 실제 계산 로직 처리
        private bool TryCalculate(decimal left, decimal right, string op, out decimal result, out string errorMessage)
        {
            result = 0m;
            errorMessage = string.Empty;

            switch (op)
            {
                case "+":
                case "＋":
                    result = left + right;
                    return true;
                case "-":
                case "－":
                    result = left - right;
                    return true;
                case "×":
                case "*":
                    result = left * right;
                    return true;
                case "÷":
                case "/":
                    if (right == 0m)
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

        private bool TryGetCurrentInput(out decimal value)
        {
            return decimal.TryParse(currentInput, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        // 화면 표시 업데이트
        private void UpdateDisplays()
        {
            if (string.IsNullOrEmpty(currentOperator))
            {
                if (!lastActionWasEquals)
                {
                    txtInputWindow.Text = string.Empty;
                }

                txtOutputWindow.Text = string.IsNullOrEmpty(currentInput) || currentInput == "-" ? "0" : currentInput;
                return;
            }

            txtInputWindow.Text = $"{FormatDecimal(firstOperand)} {currentOperator}";
            txtOutputWindow.Text = string.IsNullOrEmpty(currentInput) || currentInput == "-" ? "0" : currentInput;
        }

        // 전체 상태 초기화
        private void ResetForNewCalculation()
        {
            currentInput = string.Empty;
            firstOperand = 0m;
            currentOperator = string.Empty;
            isWaitingForSecondOperand = false;
            lastActionWasEquals = false;

            txtInputWindow.Text = string.Empty;
            txtOutputWindow.Text = "0";
        }

        // 전각 숫자를 일반 숫자로 변환 (예외 처리용)
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

        private static decimal ParseOrZero(string text)
        {
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value) ? value : 0m;
        }

        private static string FormatDecimal(decimal value)
        {
            return value.ToString("0.############################", CultureInfo.InvariantCulture);
        }
    }
}
