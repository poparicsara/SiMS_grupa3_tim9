   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IS_Bolnica.PatientPagesIS_Bolnica.PatientPages  5      )    #IS_Bolnica.PatientPages.Suggestions   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IS_Bolnica.PatientPages     5        N� Title$  Suggestions��5	      .��5      � .+�5   
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
   -   5        $��SuggestionsDataBinding��5         AutoGenerateColumns .  $	��295��5      $	��629��5         ColumnHeaderHeight$ 30Q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 162.5 5      $��15(�5      $��Center=�5         
IsReadOnly . $��Center=�5      $��37,141,22.8,34.4q�6&    J� RenderTransformOrigin$ 1.721,0.487&�6@    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value��%  '        �� 5      "	  6   .�5      �� 
 � �� �	#FF4E8E7363   �� 5       
 � ��$ Center=�6C   �� 5!      
 � ��$ 30��6/   �� 5"      
 � ��$ 1q�68   �� 5#      
 � ��
 �   �64   �� 5$      
 � ��$
 Bold"�63   5%      5&         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Width$	 213 6%      Header$ Datum i vreme��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *DateOfAppointment+  5)      $	 213 6%   $	 Ime��61    6>   �� *Doctor.Name+  5*      $	 213 6%   $ Prezime��61    6B   �� *Doctor.Surname+5,      �� 5-   
   $��Predlozi za vas��6   $��35(�6*   $
��Left=�68   $��56��6S   $��
231,60,0,0q�6_   $	��Top=�6s   $	��246��6�   �� 5.   
   $��nasLogo.jpg��6   $
��Fill=�6%   $��24,10,609.8,404.4q�64   �� 5/   
   $��Zdravo bolnica��6   $
��Left=�6)   $��27��6D   $��	10,66,0,0q�6P   $	��Top=�6c   $��93��6{   50      51      