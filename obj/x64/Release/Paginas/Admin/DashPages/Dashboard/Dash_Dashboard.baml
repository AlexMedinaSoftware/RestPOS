   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  B >RestPOS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RestPOSRestPOS    RestPOS.Dash_Dashboard   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     'localclr-namespace:RestPOS       N� Title$  Dash_Dashboard�� � 	Resources  �� Source�� -   Recursos��$ /Assets/Icons.xaml?�%    .���    
LightColor#���   $��20q� � ColumnDefinitions �� $
��260* ��� $
��260* ��� $
��260* � � RowDefinitions �� $
��192* ��� $
��192* �.+�� $��0��$��0��$��20q�.+���  K� ZIndex$ -1�� �� CornerRadius$ 5��$��4��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q�	   	Direction$		 -90Q�
   RenderingBias$
 Quality=�   Opacity$ .2Q�   ShadowDepth$ 1Q��  J� OpacityMask !�  !� Visual ��  �� ElementName$ Border1��    LiveCharts.Wpf.LineSeries �� 
TargetType   LiveCharts.Wpf.Series �� Property �� Value   LiveCharts.Wpf.Axis��%�   '        '  �     �� "  .���  �@ StrokeThickness$ 3Q���  �@ Stroke
 �������  �@ Fill �	#4EFFFFFF��  �@ PointGeometrySize$ 0Q���  �@ LineSmoothness$ 0Q��� "  .���  � {� .   �� $
��Auto ��� $
��Auto ��� $
��.50* ��� $	��.5* �.+��� -    ��Name$ Border1��$��0��$��4��$ 5��
��������� $��0��$��3�� 
 Color4#���  �� $��0�� �� TextAlignment$ Center=� �� Padding$ 10, 10, 0, 5q�
�������$��18(�Ganancias Ventas�� -    ��Name$  lbl_Fecha_GananciasTotales��$	��Hoy��$��1��$ Center=����	#59FFFFFF#   LiveCharts.Wpf.CartesianChart  -     Name$ Chrt_GananciasTotales��$��2��$��Stretch=�&    LiveCharts.Wpf.Charts.Base.Chart   	Hoverable . $��0,0,-4,0q�   DataTooltip Z� �� $��3��$��Center=�$��25, 0q�.+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $  Lbl_Total_GananciasTotales�����#303030$ Center=�$��40(�$��$100.000��� $��0��$��1��$��20q�.+��� $ -1��$ 5��$��4��
�������   $ 15Q�$		 -90Q�$
 Quality=�$ .2Q�$ 1Q��  !�  �� $ Border2�� ��%�   '        '  �     �� "  .���  �@ StrokeThickness$ 3Q���  �@ Stroke
 �������  �@ Fill �	#4EFFFFFF��  �@ PointGeometrySize$ 0Q���  �@ LineSmoothness$ 0Q��� "  .���  � {� .   �� $
��Auto ��� $
��Auto ��� $
��.50* ��� $	��.5* �.+��� -   $ Border2��$��0��$��4��$ 5��
��������� $��0��$��3��#���  �� $��0��$ Center=�$ 10, 10, 0, 5q�
�������$��18(�Propinas Totales�� -   $ lbl_Fecha_Propinas��$	��Hoy��$��1��$ Center=����	#59FFFFFF  -   $ Chrt_Propinas��$��2�� .  $��0,0,-4,0q� Z� �� $��3��$��Center=�$��25, 0q�.+��� $ 
Horizontal=�$��Center=�.+��� -	   $ Lbl_Total_Propinas�����#303030$ Center=�$��40(�$��$100.000��� $��0��$��2��$��20q�.+��� $ -1��$ 5��$��4��
�������   $ 15Q�$		 -90Q�$
 Quality=�$ .2Q�$ 1Q��  !�  �� $ Border3�� ��%�   '        '  �     �� "  .���  �@ StrokeThickness$ 3Q���  �@ Stroke
 �������  �@ Fill �	#4EFFFFFF��  �@ PointGeometrySize$ 0Q���  �@ LineSmoothness$ 0Q��� "  .���  � {� .   �� $
��Auto ��� $
��Auto ��� $
��.50* ��� $	��.5* �.+��� -
   $ Border3��$��0��$��4��$ 5��
��������� $��0��$��3��#���  �� $��0��$ Center=�$ 10, 10, 0, 5q�
�������$��18(�Ganancias Totales�� -   $ lbl_Fecha_Ventas��$	��Hoy��$��1��$ Center=����	#59FFFFFF  -   $ Chrt_Ventas��$��2�� .  $��0,0,-4,0q� Z� �� $��3��$��Center=�$��25, 0q�.+��� $ 
Horizontal=�$��Center=�.+��� -   $ Lbl_Total_Ventas�����#303030$ Center=�$��40(�$��$100.000��� $��1��$��0��$��20q�.+��� $ -1��$ 5��$��4��
�������   $ 15Q�$		 -90Q�$
 Quality=�$ .2Q�$ 1Q��  !�  �� $ Border4�� ��%�   '        '  �     �� "  .���  �@ StrokeThickness$ 3Q���  �@ Stroke
 �������  �@ Fill �	#4EFFFFFF��  �@ PointGeometrySize$ 0Q���  �@ LineSmoothness$ 0Q��� "  .���  � {� .   �� $
��Auto ��� $
��Auto ��� $
��.50* ��� $	��.5* �.+��� -   $ Border4��$��0��$��4��$ 5��
��������� $��0��$��3��#���  �� $��0��$ Center=�$ 10, 10, 0, 5q�
�������$��18(�Ventas Efectivo�� -   $ lbl_Fecha_Efectivo��$	��Hoy��$��1��$ Center=����	#59FFFFFF  -   $ Chrt_Efectivo��$��2�� .  $��0,0,-4,0q� Z� �� $��3��$��Center=�$��25, 0q�.+��� $ 
Horizontal=�$��Center=�.+��� -   $ Lbl_Total_Efectivo�����#303030$ Center=�$��40(�$��$100.000��� $��1��$��1��$��20q�.+��� $ -1��$ 5��$��4��
�������   $ 15Q�$		 -90Q�$
 Quality=�$ .2Q�$ 1Q��  !�  �� $ Border5�� ��%�   '        '  �     �� "  .���  �@ StrokeThickness$ 3Q���  �@ Stroke
 �������  �@ Fill �	#4EFFFFFF��  �@ PointGeometrySize$ 0Q���  �@ LineSmoothness$ 0Q��� "  .���  � {� .   �� $
��Auto ��� $
��Auto ��� $
��.50* ��� $	��.5* �.+��� -   $ Border5��$��0��$��4��$ 5��
��������� $��0��$��3��#���  �� $��0��$ Center=�$ 10, 10, 0, 5q�
�������$��18(�Ventas Transbank�� -   $ lbl_Fecha_TBK��$	��Hoy��$��1��$ Center=����	#59FFFFFF  -   $ Chrt_TBK��$��2��$��0,0,-4,0q� .   Z� �� $��3��$��Center=�$��25, 0q�.+��� $ 
Horizontal=�$��Center=�.+��� -   $ Lbl_Total_TBK�����#303030$ Center=�$��40(�$��$100.000��� $��1��$��2��$��20q�.+��� $ -1��$ 5��$��4��
�������   $ 15Q�$		 -90Q�$
 Quality=�$ .2Q�$ 1Q��  !�  �� $ Border6�� ��%�   '        '  �     �� "  .���  �@ StrokeThickness$ 3Q���  �@ Stroke
 �������  �@ Fill �	#4EFFFFFF��  �@ PointGeometrySize$ 0Q���  �@ LineSmoothness$ 0Q��� "  .���  � {� .   �� $
��Auto ��� $
��Auto ��� $
��.50* ��� $	��.5* �.+��� -   $ Border6��$��0��$��4��$ 5��
��������� $��0��$��3��#���  �� $��0��$ Center=�$ 10, 10, 0, 5q�
�������$��18(�Ventas Transferencia�� -   $ lbl_Fecha_Transferencia��$	��Hoy��$��1��$ Center=����	#59FFFFFF  -   $ Chrt_Transferencia��$��2��$��0,0,-4,0q� .   Z� �� $��3��$��Center=�$��25, 0q�.+��� $ 
Horizontal=�$��Center=�.+��� -   $ Lbl_Total_Transferencia�����#303030$ Center=�$��40(�$��$100.000��