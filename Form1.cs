using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class frmCalculator : Form
    {
        // 현재 입력 중인 숫자를 문자열 형태로 저장
        private string currentInput = string.Empty;

        // 첫 번째 피연산자 저장
        private int firstOperand = 0;

        // 현재 선택된 연산자 (+, -, *, /)
        private string currentOperator = string.Empty;

        // 두 번째 숫자 입력 대기 상태 여부
        private bool isWaitingForSecondOperand = false;

        // 마지막 동작이 '=' 버튼인지 여부
        private bool lastActionWasEquals = false;

        public frmCalculator()
        {
            InitializeComponent();

            // 버튼 이벤트 연결
            WireEvents();

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
            else
            {
                currentInput += digit;
            }

            lastActionWasEquals = false;

            // 화면 갱신
            UpdateDisplays();
        }

        // 연산자 버튼 클릭 시 처리
        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            // 현재 입력값을 정수로 변환
            if (!TryGetCurrentInput(out int number))
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

            // 두 번째 값 가져오기
            if (!TryGetCurrentInput(out int secondOperand))
            {
                MessageBox.Show("두 번째 숫자를 입력하세요.", "입력 필요", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 계산 수행
            if (!TryCalculate(firstOperand, secondOperand, currentOperator, out int result, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "계산 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 전체 수식 출력
            txtInputWindow.Text = $"{firstOperand} {currentOperator} {secondOperand} = {result}";

            // 결과 출력
            txtOutputWindow.Text = result.ToString();

            // 결과를 다음 계산에 활용
            currentInput = result.ToString();
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

        // 실제 계산 로직 처리
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

        // 현재 입력값을 int로 변환
        private bool TryGetCurrentInput(out int value)
        {
            return int.TryParse(currentInput, out value);
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

                txtOutputWindow.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;
                return;
            }

            txtInputWindow.Text = $"{firstOperand} {currentOperator}";
            txtOutputWindow.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;
        }

        // 전체 상태 초기화
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
    }
}
