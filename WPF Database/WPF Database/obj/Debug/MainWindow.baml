   M S B A M L   `   `   `  ����G  CWPF Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_DatabaseWPF_Database  5   	       WPF_Database.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPF_Database     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCustomers��5
         AutoGenerateColumns .  $
��Left=�5      $��
14,55,0,46q�5      $	��496��5         CanUserResizeRows .  ��5      �� *LoadDataBinding+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��5         Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 5         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   ��  �� Path$ id�5        5      $ Username��5      $	 100 5       .  5   %   �� $ username�5        5      $
 Last��5      $	 100 5       .  5   %   �� $ score�5      5"      �� 5#   
   -   5        $��	Data grid��5#      $
��Left=�6%   $��638,244,0,0q�6U   $	��Top=�6j   $��75��6�   	 �� IsCancel	 . 
 � Cursor$
 UpArrow��6�   5$      5%      