   M S B A M L   `   `   `  ����E  AIS_Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IS_Bolnica
IS_Bolnica  5   	       IS_Bolnica.RequestWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:IS_Bolnica     5   	     � Title$  RequestWindow��5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6D   $��702.091��6Z   $
��1024��6k   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ requestData��5
         AutoGenerateColumns .     SelectionMode$ Single=�5         
IsReadOnly . $��Stretch=�6<   $��10,65,9.6,10.4q�6Z   $��Stretch=�5         GridLinesVisibility$ Vertical=�6/   ��5
   (   ��  �� Path$ Notifications�	 � 	Resources	 5      )  #System.Windows.Controls.DataGridRow
 �� 
TargetType��%E   '        �� 5      "
  6   .�5      -   5        5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ TITLE��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 400 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Title+6N     5      $ SENDER��6%   $	 550 6P    65   �� *Sender+6P   5      5      5      