using System.Windows;
using System.Windows.Interactivity;

namespace VisibleWhenMouseOverExample
{
    public class VisibleWhenMouseOverBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            OnVisibilityChanged();
        }

        protected void OnVisibilityChanged()
        {
            AssociatedObject.Visibility =
                TargetMouseOver || SelfMouseOver
                ? Visibility.Visible : Visibility.Hidden;
        }


        #region TargetMouseOverProperty
        public static readonly DependencyProperty TargetMouseOverProperty =
            DependencyProperty.Register(
                "TargetMouseOver", typeof(bool), typeof(VisibleWhenMouseOverBehavior),
                new FrameworkPropertyMetadata(
                    false
                    , new PropertyChangedCallback(OnVisibilityChanged)
                )
            );

        public bool TargetMouseOver
        {
            get
            {
                return (bool)base.GetValue(TargetMouseOverProperty);
            }
            set
            {
                base.SetValue(TargetMouseOverProperty, value);
            }
        }
        #endregion

        #region SelfMouseOverProperty
        public static readonly DependencyProperty SelfMouseOverProperty =
            DependencyProperty.Register(
                "SelfMouseOver", typeof(bool), typeof(VisibleWhenMouseOverBehavior),
                new FrameworkPropertyMetadata(
                    false
                    , new PropertyChangedCallback(OnVisibilityChanged)
                )
            );

        public bool SelfMouseOver
        {
            get
            {
                return (bool)base.GetValue(SelfMouseOverProperty);
            }
            set
            {
                base.SetValue(SelfMouseOverProperty, value);
            }
        }
        #endregion

        private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as VisibleWhenMouseOverBehavior)?.OnVisibilityChanged();
        }
    }
}
