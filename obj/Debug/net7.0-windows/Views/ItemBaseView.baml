   M S B A M L   `   `   `  ����H  DETFHelper_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ETFHelper_WPF.ViewsETFHelper_WPF.Views  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   &     ETFHelper_WPF.Views.ItemBaseView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ETFHelper_WPF.Views     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	   $	��5,5q�5
   	   $��20(�5   	   $	��400��6   .��5      ��  %  !MahApps.Brushes.Badged.Background#���   6   $��1q�6O     �� CornerRadius$  4��6c    � Cursor$
 Hand��6t     Caliburn.Micro.Message   Attach$0 *[Event MouseDown] = [Action OnItemClicked]��6�   ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��  MahApps.Brushes.Accent4 �� Value# �  6/   6c    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��65   . �5      ��  � ��  MahApps.Brushes.Accent2# �  67   6k   5      5      ._�5   
   � 	 � ColumnDefinitions	 5      �� 5      $
��auto �6#   62   �� 5      6%   .+�5      �� -   5        
 ��Name$
 IconLink��5      $��2��6&   $��0��67   $	��100��6G   $
��Left=�6V   $��4q�6q   6~   �� 5      $��1��6   $	��0,5q�6)   .+�5      �� -   5         ��Name$ 	ShortName��5      $
��Wrap=�6/   $��Center=�6C   $
��Bold"�6`   $��25(�6r   �� 5       -   5        $
 Name��5       $
��Wrap=�6*   �� 5!      -   5        $ 	BasePrice��5!      $
��Wrap=�6/   �� 5"      -   5        $ 
TypesValue��5"      $
��Wrap=�60   5#      5$      5&      5'      