   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5   	       IS_Bolnica.RoomInventory   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:IS_Bolnica     5   	     � Title$  Inventar��5   	   $	��655��6   $	��700��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      � .+�5
   
   �� $��INVENTAR��6   $
��Left=�6$   $��
274,26,0,0q�6?   $	��Top=�6S   $��26(�6k   $
��Bold"�6y   $��Ebrima)�6�   
���   �6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ inventoryDataGrid��5      $��Center=�6/   $	��517��6L   $��Center=�6Y   $	��588��6t   $��16(�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 193.3 5         CanUserResizeRows .     CanUserResizeColumns .     CanUserAddRows .     AutoGenerateColumns .     	RowHeight$ 30Q�5      $��53,99,52.6,9.6q�6"   $��8q�6:   
���   ���6b   �� 	 �� Path$	 RoomInventory�
 � 	Resources
 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%3  '        �� 5      "  6   .�5      ��  � ��
 �����63   �� 5       � ��$ Center=�6C   �� 5       � ��$ 35��6/   �� 5       � ��$ 1q�68   �� 5       � ��
 �   �64   �� 5       � ��$
 Bold"�63   �� 5       � ��$ 18(�61   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$ 188.5 6%      Header$ ID��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Id+  5      $ 188.5 6%   $ NAZIV��63    6C   �� *Name+  5      $ 188.5 6%   $ TRENUTNA KOLIČINA��63    6O   �� *CurrentAmount+5!      5#      5$      