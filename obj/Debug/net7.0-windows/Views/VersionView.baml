   M S B A M L   `   `   `  ����H  DETFHelper_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ETFHelper_WPF.ViewsETFHelper_WPF.Views  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      %    ETFHelper_WPF.Views.VersionView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ETFHelper_WPF.Views     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      $
��auto��5
      $
��auto��5      .��5      � .+�5   
   �� $��5q�6     �� Orientation$  
Horizontal=�6!   $��Center=�6;   .+�5      �� $
��15,0q�61   $��25(�6?     Caliburn.Micro.Message   Attach$2 ,[Event MouseDown] = [Action OpenReleasePage]��6M    � Cursor$
 Hand��6�   ��6   �� *	Version+6�   �� 5      $
 Hand��6    %  !MahApps.Brushes.Badged.Background#���   6#   $0 *[Event Click] = [Action UpdateApplication]��5      y�5      �� *
NeedUpdate+   BooleanToVisibilityConverter �� 	Converter# [  � 	Resources 5       �� 
TargetType �� Property �� Value  MahApps.Brushes.Accent3 �� 
TargetType	 �� Triggers
 P� Property P� Value  MahApps.Brushes.Accent2��%�  '��       '�� U     �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��69   5      �� 5      " ��6   .�5      ��  � ��# �  67   6k   �� 5       � �� 5      �� 5   "   " ��62   .R�5   &   �� #��z��6-   ._�5   *   �� $��Center=�6;   $��Center=�6X   5   '   5   #   5       	 5!      P� 5"      
 �@J�IsMouseOver$
 True��6=   . �5#   "   ��  � ��# �  6?   5$      5&      5'      .��5(      �� $��5q�6   $��Update��6'    
 Bender#��[ 65   $��20(�6Z   5)      5+      5,      5-      