   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5   	   "    IS_Bolnica.IngredientsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:IS_Bolnica     5   	     � Title$!  MedicamentCompositionWindow��5   	   $	��655��6-   $	��700��6:    � WindowStartupLocation$ CenterScreen=�6F    � 	Resources 5	         
addCommand  editCommand  deleteCommand��%W   &	        &	      &	 &     �� 5
   
   6   �� 5   
   6   �� 5   
   6   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6?     5   
   -   5        # [ 5      6@     5   
   -   5        # [ 5      6B    J� InputBindings 5      �� 5   
    �� Command# [  6   
 �� Key$ N��6;    �� 	Modifiers$ Controlf�6C   �� 5   
   # [ 6   $ E��6<   $ Controlf�6D   �� 5   
   # [ 6   $ D��6>   $ Controlf�6F   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 ingredientDataGrid��5      $��Center=�60   $	��458��6M   $��Center=�6Z   $	��438��6u   $��16(�6�   
   CanUserResizeRows
 .     CanUserResizeColumns .     CanUserAddRows .     AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5   %      CanUserDeleteRows . $��132,133,123.6,34.6q�6U   
���   �$��8q�5   (      	RowHeight$ 30Q�6<   $   HorizontalScrollBarVisibility$ Hidden=�6K    5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%3  '        �� 5      "  6   .�5       ��  � ��
 �����63   �� 5!       � ��$ Center=�6C   �� 5"       � ��$ 35��6/   �� 5#       � ��$ 1q�68   �� 5$       � ��
 �   �64   �� 5%       � ��$
 Bold"�63   �� 5&       � ��$ 18(�61   5'      5(         Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 417 6%      Header$ NAZIV��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name+5-      �� 5.   
   -   5        ��. $
��Left=�5.   "   $��612,556,0,0q�6=   $	��Top=�6R   $��35��6j   $��35��6v   .��5/      �� .+�50      �� $��DemoMode/addIcon.png��6   51      52      �� 53   
   -   5        ��. 
�������$
��Left=�53   5   $��612,497,0,0q�6P   $	��Top=�6e   $��35��6}   $��35��6�   .��54      �� .+�55      �� $��DemoMode/delete.png��6   67   56      57      �� 58   
   -   5        ��. 
�������$
��Left=�58   5   $��612,437,0,0q�6P   $	��Top=�6e   $��35��6}   $��35��6�   .��59      �� .+�5:      �� $��DemoMode/edit.png��6   65   5;      5<      �� 5=   
   $��SASTOJCI��6   $
��Left=�6#   $��
291,44,0,0q�6>   $	��Top=�6R   $��26(�6j   $
��Bold"�6x   �� 5>   
   $��CTRL+E��6   $
��Left=�6!   $��622,422,0,0q�6<   $	��Top=�6Q   $��8(�6i   $
��Bold"�6v   �� 5?   
   $��CTRL+D��6   $
��Left=�6!   $��622,481,0,0q�6<   $	��Top=�6Q   $��8(�6i   $
��Bold"�6v   �� 5@   
   $��CTRL+N��6   $
��Left=�6!   $��622,541,0,0q�6<   $	��Top=�6Q   $��8(�6i   $
��Bold"�6v   5A      5B      