   M S B A M L   `   `   `  ���� B  >RestPOS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RestPOSRestPOS      RestPOS.DetalleMesa   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:RestPOS       N� Title$  Login�� � 	Resources  �� Source�� -   Recursos��$ /assets/icons.xaml?�%    .��]�    BackgroundColor#���   .+�� -    �Name$ 
OptionsBar��$��80��$	��Top=� � ColumnDefinitions �� $	��100��$	��135���� $	��100��$	��135���� $	��100��$	��135���� $	��100���� $	��100��$	��135���� $	��100��$	��135���� $	��100��$	��135���� $	��100��$	��135��.+�� -   $ BackKey��$��0��  	HoverMenu#���  .+�� $��55��.+���  	 Atras#���  $��30��$��30��$	��Top=�$��Center=��� $��Atras��$��Bottom=�$��Center=�  	TextColor#���  $&�� /RestPOS;component/Fonts/#Roboto)�� -   $ 	SearchKey��$��1��#���  .+�� $��55��.+���  
 Search#���  $��30��$��30��$	��Top=�$��Center=��� $��Buscar��$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�� $��2��#���  .+�� $��55��.+���   Barcode#���  $��30��$��30��$	��Top=�$��Center=��� $��Codigo��$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�� $��3��.+�� $��55��.+��� -    ��Name$
 Logo��  
SimpleLogo#���  $��65��$��55��$��Bottom=�$��Center=�� -   $ 	SendToBar��$��4��#���  .+�� $��55��.+���   Beer#���  $��30��$��30��$	��Top=�$��Center=��� $��Enviar al bar��$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�� -   $ SendToKitchen��$��5��#���  .+�� $��55��.+���   Cutlery#���  $��30��$��30��$	��Top=�$��Center=��� $��Enviar a cocina��$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�� -   $ SendAll��$��6��#���  .+�� $��55��.+���  	 Receipt#��� 	 $��30��$��30��$	��Top=�$��Center=��� $��Recibo��$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�� -	   $	 Pay��$��7��#���  .+�� $��55��.+���  
 Pay#��� 
 $��30��$��30��$	��Top=�$��Center=��� $��Pagar��$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�� $
��Left=�$��70��  
DarkColor1#���   � RowDefinitions �� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� �� $��70 ��� $��70 �.+��� $��0,0,0,1q�  	LineColor#���  $��0��._�� -
   $ Mod_Cantidad��
 � Tag$ Mod_Cantidad��  HoverActions#���  .+��� $��0,5,0,0q�  Add#���  $	��Top=�$��35���� $��0,0,0,5q�$��CANTIDAD��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"��� $��0,0,0,1q�#���  $��1��._�� -   $ 
Mod_Precio��$ 
Mod_Precio��#���  .+��� $��0,5,0,0q� 	 Price#���  $	��Top=�$��35���� $��0,0,0,5q�$��PRECIO��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"��� $��0,0,0,1q�#���  $��2��._�� -   $ Mod_Detalle��$ Mod_Detalle��#���  .+��� $��0,5,0,0q� 
 Detail#���  $	��Top=�$��35���� $��0,0,0,5q�$��DETALLE��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"��� $��0,0,0,1q�#���  $��3��._�� -   $ Mod_Modificar��$ Mod_Modificar��#���  .+��� $��0,5,0,0q�  	Modificar#���  $	��Top=�$��35���� $��0,0,0,5q�$��	MODIFICAR��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"��� $��0,0,0,1q�#���  $��4��._�� -   $ 
Mod_Tiempo��$ 
Mod_Tiempo��#���  .+��� $��0,5,0,0q�  Time#���  $	��Top=�$��35���� $��0,0,0,5q�$��TIEMPO��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"��� $��0,0,0,1q�#���  $��5���� $��0,0,0,1q�#���  $��6��._�� -   $ btn_Mesa��#���  .+��� $��0,5,0,0q�  Mesa#���  $	��Top=�$��35���� -    ��Name$ 	LabelMesa��$��0,0,0,5q�$
��MESA��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"��� $��0,0,0,0q�#���  $��7��._�� #���  .+��� $��0,5,0,0q� 
 Person#���  $	��Top=�$��35���� -   $ NombreTrabajador��$��0,0,0,5q�$
��NAME��$��10(�$��Bottom=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$
��Bold"�� $	��120��$��Bottom=����	#FF171717.+�A� -   	 A�Name$	 
Categories��
 A� Rows$
 1��$
��Left=�� $��Right=�$	��600��#���  .+�&   System.Windows.Controls.DataGrid  -     Name$ ListaPedido�� 	 table#���     RowDetailsVisibilityMode$ 	Collapsed=�   CanUserAddRows .     CanUserDeleteRows .  ��.     CanUserReorderColumns .  
�������$��0,0,0,60q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 QNT��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60  �� TextAlignment$ Center=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *P_Item_Cantidad+  $ PRODUCTO��   	FontStyle$ Italic$�$ *  �� *P_Item_Nombre+  $ PRECIO��$	 100 $ Right=� �� *P_Item_Precio+  $ TOTAL��$	 100 $ Right=� �� *P_Item_Total+   RowDetailsTemplate �� .R���   dg-cell-textblock#���  $��10q����� *P_Item_Details+� $��Bottom=�$��60��.+��� #���   J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$ 90Q�   
BlurRadius$ 40Q�   ShadowDepth$ 27Q�   Color$ 	#FF7A838E��   RenderingBias$ Quality=�   Opacity$ 0Q��� -    ��Name$ DelItem��  
DarkColor2#��[ $	��100��$��30��$
��Left=�$��Bottom=�$��10q� �� CornerRadius$ 5��  	HoverPass#���  ._��� $��Eliminar Item��$��Stretch=�$��Stretch=�$��12(�$��Center=�$��Center=�$&�� /RestPOS;component/Fonts/#Roboto)�  
LightColor#���  �� $��TOTAL��$��Right=�$��Stretch=�$	��Top=�$��Center=�$&�� /RestPOS;component/Fonts/#Roboto)�#���  �� -   $ 
LabelTotal��$��$0��$��Right=�$��Stretch=�$��30(�$��Bottom=�$&�� /RestPOS;component/Fonts/#Roboto)�#���  � $��Stretch=�$
��Auto=�$��Stretch=�#���  .+�� -     �Name$  PopUpSearch����.  ! � 	StaysOpen! .  $	��420��$��70��$��Relative=�$	��Top=�$
��Left=�$��10q�" � HorizontalOffset$" 10��# � VerticalOffset$# 10��$ � AllowsTransparency$ . .���� $��Center=�$	��400��$��50��$��Center=�#���  $ 3��$��0q�  ButtonColor#���     $ 0Q�$ 10Q�._��� -   % ��Name$% TextBoxBusqueda��& J� Opacity$	& 0.9Q�
������ $��0q�$��Center=�$��	10,0,10,0q�
������ #���  $&�� /RestPOS;component/Fonts/#Roboto)�$��25(�$
��Bold"�� -   $  	PopUpQnty����.  $	��220��$	��220��$��Center=�$ . .���� $��Center=�$	��200��$	��200��$��Center=�#���  $ 3��$��0q�#���     $ 0Q�$ 10Q�._�A� -   $	 PopUpQntyGrid��$��Stretch=�$��Stretch=�$
 3��' A� Columns$' 3��� -   $  
PopUpPrice����.  $	��220��$	��320��$��Center=�$ . .���� $��Center=�$��Center=�$	��200��$	��300��#���  $ 3��$��0q�#���     $ 0Q�$ 10Q�._�� .+��� $��Stretch=�$	��top=�$��50��._��� -   $% PopUpPriceText��$�� ��$��Stretch=�$��Stretch=�$��35(�$��5,0,5,0q�|�. ( �� TextAlignment$( Right=�
������ #���  ) �� 
CaretBrush#) �  ��Z� * �� SelectionBrush* Z� A� -   $	 PopUpPriceGrid��$��Stretch=�$��0,50,0,0q�$��Stretch=�$
 4��$' 3��� -   $  PopUpModificar����.  $	��438��$	��420��$��Center=�$ . .���� $��Center=�$	��418��$	��400��$��Center=�#���  $ 3��$��0q�#���     $ 0Q�$ 10Q�._�� .+��� $��Hidden=�$��Visible=�+ J� IsHitTestVisible+ . 
������ $��0,0,0,60q�.��A� -   $	 PopUpModificarGrid��$	��Top=�$��Stretch=�$' 4��$��0,0,0,0q��� $��60��$��Bottom=�$ 0,0,3,3��._�� .+���  
 Color5#���  $��Right=�$��3,3,3,3q�$	��100��$ 3��._��� -   $ PopUpModificarOK��$��Aceptar��$��Center=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$��15(�$
��Bold"��� #���  $��Right=�$��	3,3,109,3q�$	��100��$ 3��._��� -    $ PopUpModificarCancelar��$��Cancelar��$��Center=�$��Center=�#���  $&�� /RestPOS;component/Fonts/#Roboto)�$��15(�$
��Bold"�� -!   $  PopUpDetail����.  $	��200��$	��300��� -"   $  	PopUpTime����.  $	��200��$	��300���� $��Stretch=�$
��Auto=�$��Stretch=�#���  .��A� -#   $	 	Productos��$	��Top=�$' 6��