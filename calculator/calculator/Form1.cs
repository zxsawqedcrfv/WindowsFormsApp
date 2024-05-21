using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication2
{
  public partial class Form1 : Form
  {
      string sum = "";
      double? A = null;//數值1
      double? B = null;//數值2
      string c = "";//按鍵標題(button.Text)
      string point = ".";//判斷字串中是否有小數點
      Button btn;
      public Form1()
      {
          InitializeComponent();
      }
      private void button1_Click(object sender, EventArgs e)
      {
          btn = (Button)sender;
          Calculator_Design_By_Peggy();
      }
      private void Calculator_Design_By_Peggy()
      {
          switch(btn.Text)
          {
              case "C"://Allclear
               sum = "";
               A = null;
               B = null;
               label3.Text = "";
               break;
              case "←"://刪除最後一項
               sum = label1.Text;//用於按下等號後，因為sum值在按下運算符後會清空，用lable.Text存回顯示之字串
               if (sum.Length > 0)
               { sum = sum.Substring(0, sum.Length - 1); }
               break;
              case "+":
              case "-":
              case "*":
              case "/":
              case "=":
                  if (sum != "")
                  {
                    if (A.HasValue)
                    {
                        B = Convert.ToDouble(sum);//A有數值，sum字串轉數值儲存於B，並與A進行運算
                      if (c == "+")//此時判斷的c，為上一次按下的運算符
                        sum = (A + B).ToString();
                      else if (c == "-")
                        sum = (A - B).ToString();
                      else if (c == "*")
                        sum = (A * B).ToString();
                      else if (c == "/")
                        sum = (A / B).ToString();
                    }
                    A = Convert.ToDouble(sum);//A無數值，sum字串轉數值儲存於A，反之，計算結果取代原本A值
                  }
                  c = btn.Text;
                  if (c != "=")
                  { 
                  label3.Text = A.ToString() + c;//label 3 顯示當前A值與運算符
                  label1.Text = "";//清空label 1 以輸入下一個數值
                  }
                  else
                  { 
                  label1.Text = A.ToString();//當按下等號，顯示運算結果於lable 1
                  label3.Text = "";//清空lable 3 的文字
                  }
                  sum = "";
               break;
              default://加入數字，小數點
               sum += btn.Text;
               break;
          }   
          if (sum.Contains(point))
          { button12.Enabled = false; }//有小數點不能按
          else
          { button12.Enabled = true; }//沒小數點可按
          if (sum != "" || btn.Text == "←" || btn.Text == "C")//加入數字、刪去最後一個元素及按下AllClear時
              label1.Text = sum;
      }
      private void timer1_Tick(object sender, EventArgs e)
      {
          label2.Text = "現在時間："+DateTime.Now.ToString();
      }
  }
}
