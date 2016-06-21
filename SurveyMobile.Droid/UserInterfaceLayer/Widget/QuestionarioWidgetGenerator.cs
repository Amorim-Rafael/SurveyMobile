using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SurveyMobile.Droid.Domain.Survey;

namespace SurveyMobile.Droid.UserInterfaceLayer.Widget
{
    public class QuestionarioWidgetGenerator
    {
        public QuestionarioWidgetGenerator(){}

        public static RadioButton createRadioButton(RadioGroup radioGroup, int page, int id, string text, bool flag)
        {
            RadioButton radioButton = new RadioButton(radioGroup.Context);
            radioButton.Id = id;
            radioButton.Text = text;
            radioButton.TextSize = 18;
            radioButton.Checked = flag;
            //radioButton.SetOnClickListener(new View.IOnClickListener() { });
            radioButton.Click += (sender, e) =>
            {
                View v = (View)sender;
                QuestionarioManager.getInstance().updateFirstOptionSelected(page, v.Id);
            };

            if (flag)
                radioButton.Checked = true;

            radioGroup.AddView(radioButton, -2, -2);
            return radioButton;
        }
    }
}