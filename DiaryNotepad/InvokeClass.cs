using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryNotepad
{
    public static class InvokeClass
    {
        public static void InvokeForm(this Form form, Action<Form> func)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(func);
            }
            else
            {
                func(form);
            }
        }
        public static T InvokeForm<T>(this Form form, Func<Form, T> func)
        {
            if (form.InvokeRequired)
            {
                return (T)form.Invoke(func);
            }
            else
            {
                return func(form);
            }
        }
        public static void InvokeControl(this Control ctl, Action<Control> func)
        {
            if (ctl.InvokeRequired)
            {
                ctl.Invoke(func);
            }
            else
            {
                func(ctl);
            }
        }
        public static T InvokeControl<T>(this Control ctl, Func<Control, T> func)
        {
            if (ctl.InvokeRequired)
            {
                return (T)ctl.Invoke(func);
            }
            else
            {
                return func(ctl);
            }
        }
    }
}
