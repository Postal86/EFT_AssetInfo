   M S B A M L   `   `   `  ����H  DETFHelper_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ETFHelper_WPF.ViewsETFHelper_WPF.Views  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      (    "ETFHelper_WPF.Views.ItemDetailView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ETFHelper_WPF.Views     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      $��25(�5
      .��5      �� $��5q�6   .��5   
   � $
��auto��6     � ColumnDefinitions  5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5       �� -   5         ��Name$
 Name��5       $��Center=�6&   $
��10,0q�6C   $��1��6Q   $��2��6a   $
��Wrap=�6r   6�   �� 5"      $��0��6   $��2��6"   $��4q�63   $	��200��6>    �� CornerRadius$ 8��6K   ��5#      �� 5$       �� Color$ White��6&    �� Opacity$
 0.05Q�64   5%      ._�5'      �� -   5         ��Name$ 	ImageLink��5'      $��Center=�6+   $��Center=�6F   $	��200��6d   6v   5(      �� 5*      $��
Base price��6   $��Center=�6*   $��2��6G   6V   �� 5+      -   5        $ 	BasePrice��5+      $��2��6+   $��1��68   $
��10,0q�6H   $��Center=�6V   6u   �� 5-      $��Types��6   $��Center=�6%   $��3��6B   6Q   �� 5.      -   5        $ 
TypesValue��5.      $��3��6,   $��1��69   $
��10,0q�6I   $��Center=�6W   $
��Wrap=�6t   6�   �� 50      $��Accuracy modifier��6   $��Center=�61   $��4��6N   y�6[   �� *AccuracyModifier+   IntToVisibilityConverter �� 	Converter# [  6�   �� 51      -   5        $ AccuracyModifier��51      $��4��62   $��1��6?   $
��10,0q�6�   $��Center=�6�   y�6O   �� *AccuracyModifier+# [  6�   �� 53      $��Recoil modifier��6   $��Center=�6/   $��5��6L   y�6Y   �� *RecoilModifier+# [  6�   �� 54      -   5        $ RecoilModifier��54      $��5��60   $��1��6=   $
��10,0q�6�   $��Center=�6�   y�6M   �� *RecoilModifier+# [  6�   �� 56      $��Ergonomics modifier��6   $��Center=�63   $��6��6P   y�6]   �� *ErgonomicsModifier+# [  6�   �� 57      -   5        $ ErgonomicsModifier��57      $��6��64   $��1��6A   $
��10,0q�6�   $��Center=�6�   y�6Q   �� *ErgonomicsModifier+# [  6�   �� 59       % !MahApps.Brushes.Badged.Background#���  6     MahApps.Brushes.Accent4#���  6W   $��3q�6�   $ 15��6�   $��7��6�   $��0��6�   $��Center=�6�   $
��0,10q�6�   y�6�   �� *CanBuy+   BooleanToVisibilityConverter# [ ._�5:      �� .+�5;      �� $	��Buy��6    $��Center=�6+   6J   �� 5<      -   5         ��Name$ BuyFor��5<   #   ��5=      �� 5>      .R�5?   "   �� 5@      5B      5C      5D      �� 5F      $��Can not buy this item��6   $
��Wrap=�65   $��7��6�   $��0��6�   $��Center=�6�   $
��0,10q�6�   y�6I   �� *	CanNotBuy+# [ 6�   �� 5H      #���  6   #���  6W   $��3q�6�   $ 15��6�   $��7��6�   $��1��6�   $��Center=�6�   $
��0,10q�6�   y�6�   �� *	CanSell+# [ ._�5I      �� .+�5J      �� $
��Sell��6    $��Center=�6,   6K   �� 5K      -	   5        $ SellFor��5K   #   ��5L      �� 5M      .R�5N   "   �� 5O      5Q      5R      5S      �� 5U      $��Can not sell this item��6   $
��Wrap=�66   $��7��6�   $��1��6�   $��Center=�6�   $
��0,10q�6�   y�6J   �� *
CanNotSell+# [ 6�   �� 5W      $��8��6   $��2��6"   $��Center=�66   	 � Cursor$
	 Hand��5X      #���  6     Caliburn.Micro.Message
   Attach$'
 ![Event Click] = [Action OpenWiki]��5Y      y�5Z      �� *HasWikiLink+# [  � 	Resources 5[       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  MahApps.Brushes.Accent2��%�  '��       '�� U     �� 5\      " ��6   .�5]      ��  �@��CornerRadius$ 10��69   5^      �� 5_      " ��6   .�5`      ��  � ��# �  67   6k   �� 5a       � �� 5b      �� 5c   "   " ��62   .R�5d   &   �� #��z��6-   ._�5e   *   �� $��Center=�6;   $��Center=�6X   5f   '   5g   #   5i       5j      P� 5k       �@J�IsMouseOver$
 True��6=   . �5l   "   ��  � ��# �  6?   5m      5o      5p      .��5q      �� $��5q�6   $��	Open wiki��6'    
 Bender#��[ 68   $��25(�6^   5r      5t      5u      5v      