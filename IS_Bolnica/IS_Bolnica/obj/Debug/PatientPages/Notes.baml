   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IS_Bolnica.PatientPagesIS_Bolnica.PatientPages  5      #    IS_Bolnica.PatientPages.Notes   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IS_Bolnica.PatientPages     5        N� Title$  Notes��5	      .��5      � .+�5   
    � -   5        $��
StartFrame��5   �     � NavigationUIVisibility$ Hidden=�6   $
��Left=�60   $	��470��6K   $	��Top=�6X   $	��689��6p   $��
1,0,-1.2,0q�6|   6�   �� 5   
   -   5        $��549,33,22.8,390.4q�5   +   
�������.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��back.png��6   $
��Fill=�6*   $��30��69   $��36��6E   �� 5      $
��Back��6   $��16(�6'   $
��Left=�65   $��27��6P   $	��Top=�6\   $��48��6t   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��NotesDataBinding��5         AutoGenerateColumns .  $	��281��5      $	��479��5         ColumnHeaderHeight$ 30Q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 479 5      $��15(�5      $��Center=�5         
IsReadOnly . $��Center=�5      $��28,153,181.8,36.4q�6&    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType	 �� Property
 �� Value��%  '        �� 5      "  6   .�5      �� 	 � ��
 �	#FF4E8E7363   �� 5       	 � ��$
 Center=�6C   �� 5!      	 � ��$
 30��6/   �� 5"      	 � ��$
 1q�68   �� 5#      	 � ��

 �   �64   �� 5$      	 � ��$

 Bold"�63   5%      5&         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ Beleska��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Comment+5+      �� 5,   
   -   5        $��524,337,22.8,85.4q�5,   *   
�������.��5-      �� $ 
Horizontal=�6   .+�5.      �� $��add.png��6   $
��Fill=�6)   $��30��68   $��32��6D   �� 5/      $��Unesi belesku��6   $��15(�60   $
��Left=�6>   $��29��6Y   $	��Top=�6e   $	��101��6}   50      51      �� 52   
   $��Unete beleske��6   $��26(�6(   $
��Left=�66   $��54��6Q   $��
241,60,0,0q�6]   $	��Top=�6q   $	��193��6�   �� 53   
   $��nasLogo.jpg��6   $
��Fill=�6%   $��24,10,609.8,404.4q�64   �� 54   
   $��Zdravo bolnica��6   $
��Left=�6)   $��27��6D   $��	10,66,0,0q�6P   $	��Top=�6c   $��93��6{   �� 55   
   $
��Back��6   $��16(�6   $
��Left=�6-   $��27��6H   $��
715,27,0,0q�6T   $	��Top=�6h   $��48��6�   �� 56   
   $ 
Horizontal=�6   $
��Left=�6.   $��33��6I   $	��Top=�6U   $	��196��6m   $��
28,119,0,0q�6y   .+�57      �� $��
search.jpg��6   $
��Fill=�6(   $��33��67   $��46��6C   $��
0,0,0,-0.2q�6O   �� 58      -   5        $��	SearchBox��58   X   $��20(�6*   $��
0,0,0,-0.2q�68   $	��150��6L   6X   59      5:      5;      