   M S B A M L   `   `   `  ����B  >RestPOS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RestPOSRestPOS  5   	       RestPOS.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:RestPOS     5   	     � Title$  
MainWindow��5   	   $	��768��6   $
��1366��6)    � WindowStyle$
 None=�66    � WindowState$ 	Maximized=�6I    � WindowStartupLocation$ CenterScreen=�6a    � 	Resources 5	       �� Source�� 5
   
   -   5        Recursos��$ /Assets/Icons.xaml?�5
   /   %    .��5      � ���#0E0E0E$��Stretch=�6    $��Stretch=�6<   .+�5   
   � -   5         �Name$ PopupWindow��5      $	��800��6%   $	��600��61   $��Center=�6>   ��.   � 	StaysOpen . $��Center=�6q   $��Center=�6�    � AllowsTransparency . .��5      �� $��Center=�6   $��Center=�60   $	��750��6M   $	��450��6Y   ���#414246	 �� CornerRadius$	 10,10,10,10��6{   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6'      ShadowDepth$ 0Q�65      Opacity$	 0.5Q�6E      
BlurRadius$ 16Q�6S   ._�5      � .+�5      �� $	��Top=�6   $��Stretch=�61   $��50��6O   ���#2E2F33$	 	10,10,0,0��6p    �� Padding$ 10,0,0,0q�6�   ._�5      � $��Stretch=�6   $��Stretch=�67   .+�5      � -   5         �Name$ 
PopupClose��5      $��Center=�63   $
��Left=�6N   $��24��6i   $��24��6t   .+�5      ��  	  Close#��[  6$   5      � 5      $��Stretch=�6   $��Center=�6;   $	��600��6X   .+�5      �� -   5         ��Name$ 
PopupTitle��5   $   $��Stretch=�68   $��Stretch=�6T   $��Center=�6r   $��Center=�6�     	TextColor#���  6�   $
��HOLA��6�   $��24(�6�   $+��%/MisterFiesta;component/fonts/#Roboto)�6�   63  5      5      5      �� 5      -   5         ��Name$ PYesBtn��5      $y�Visible=�6*   $��Bottom=�6?   $��Right=�6Z   $��	0,0,20,20q�6v   $	��140��6�   $��50��6�   $	 10��6�     ButtonColor#���  6�   6�   �� 5      -   5        $ PNoBtn��5      $y�Visible=�6-   $��Bottom=�6B   $��Right=�6]   $��
0,0,175,20q�6y   $	��140��6�   $��50��6�   $	 10��6�   #���  6�   6�   �� 5      -   5        $ 
PCenterBtn��5      $y�Visible=�61   $��Bottom=�6F   $��Center=�6a   $��0,0,0,50q�6~   $	��200��6�   $��50��6�   $	 10��6�   #���  6�   6�   5       5!      5"      ]� 5#   
   $��Stretch=�6   $��Stretch=�60   .+�5$      � $	��Top=�6   $��50��6(   $��Stretch=�64   ���	#FF1B1B1B.+�5%      � -   5        $ ShutDown_btn��5%      $��Center=�6-   $��Right=�6H   $��36��6d   $��36��6o   $��7,0,7,0q�6{   .+�5&      �� -	   5         ��Name$ ShutdownIcon��5&        PowerShutdown#��[ 62   5'      � 5(      $��Center=�6   $��Center=�62   $
��1200��6O   $��36��6\   $��7,0,7,0q�6h   .+�5)      �� -
   5        $ Titulo��5)      $��Simple.��6,   #���  6>   $��Stretch=�6g   $��Stretch=�6�   $��Center=�6�   $��Center=�6�   $��20(�6�   $+��%/MisterFiesta;component/fonts/#Roboto)�6�   5*      �� 5+      -   5        $ 
TextoReloj��5+      $��00:00:00��6,   #���  6?   $��Stretch=�6h   $
��Left=�6�   $��Center=�6�   $��Center=�6�   $��20(�6�   $��7,0,0,0q�6�   $+��%/MisterFiesta;component/fonts/#Roboto)�6  69  5-      � 5.      $
��Left=�6   $��50��6)   $��Stretch=�64   
����  �$y�	Collapsed=�6b   50      � 51      $��Right=�6   $��Stretch=�6*   $��Stretch=�6H   ���	#FFBDBDBD.+�52       � -   5          �Name$ 	MainFrame��52   �   $��Stretch=�6   $��Stretch=�66   $��Stretch=�6R   $��Stretch=�6w     � NavigationUIVisibility$ Hidden=�6�   6�   53      55      57      58      