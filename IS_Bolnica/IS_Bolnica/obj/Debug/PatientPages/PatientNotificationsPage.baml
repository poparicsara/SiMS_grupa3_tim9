   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IS_Bolnica.PatientPagesIS_Bolnica.PatientPages  5      6    0IS_Bolnica.PatientPages.PatientNotificationsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IS_Bolnica.PatientPages     5        N� Title$  PatientNotificationsPage��5	      .��5      � .+�5   
   �� $��27,17,611.8,405.4q�6   $��nasLogo.jpg��6+   $
��Fill=�6@   �� 5   
   $��Zdravo bolnica��6   $
��Left=�6)   $��27��6D   $��	10,66,0,0q�6P   $	��Top=�6c   $��93��6{   &   System.Windows.Controls.DataGrid  5   
   -   5        $��patientNotificationsGrid��5         AutoGenerateColumns .  $	��277��5      $	��650��5         ColumnHeaderHeight$ 30Q�5      $��15(�5      $��Center=�5         
IsReadOnly . $��Center=�5      $��16,155,22.8,38.4q�6&    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%  '        �� 5      "  6   .�5      ��  � �� �	#FF4E8E7363   �� 5       � ��$ Center=�6C   �� 5       � ��$ 30��6/   �� 5       � ��$ 1q�68   �� 5       � ��
 �   �64   �� 5       � ��$
 Bold"�63   5      5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 186 6%   
   Header$
 Naslov��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Title+  5#      $		 464 6%   $
 Sadržaj��61    6B   �� *	Content+5&      �� 5'   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��33��6I   $	��Top=�6U   $	��198��6m   $��
16,122,0,0q�6y   .+�5(      �� $��
search.jpg��6   $
��Fill=�6(   $��33��67   $��46��6C   $��
0,0,0,-0.2q�6O   �� 5)      -   5         ��Name$ 	SearchBox��5)   X   $��20(�6*   $��
0,0,0,-0.2q�68   $	��150��6L   6X   5*      �� 5+   
   $��Pacijentova obaveštenja��6   $��26(�62   $
��Left=�6@   $	��Top=�6[   $��
204,48,0,0q�6s   $	��290��6�    J� RenderTransformOrigin$ 0.412,0.348&�6�   �� 5,   
   -   5        $��549,33,22.8,390.4q�5,   +   
�������.��5-      �� $ 
Horizontal=�6   .+�5.      �� $��back.png��6   $
��Fill=�6*   $��30��69   $��36��6E   �� 5/      $
��Back��6   $��16(�6'   $
��Left=�65   $��27��6P   $	��Top=�6\   $��48��6t   50      51      53      54      