   M S B A M L   `   `   `  ����E  AEZ Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:EZ_Console
EZ_Console  5   	       EZ_Console.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:EZ_Console     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $��388.993��6)    � 
ResizeMode$ NoResize=�69   .��5
      � .+�5   
   �� -   5         ��Name$ cBoxCOMPORT��5      $
��Left=�6(   $��
178,99,0,0q�6C   $	��Top=�6W   $	��120��6o   �� 5   
   -   5        $ cBoxBaudRate��5      $
��Left=�6)   $��178,137,0,0q�6D   $	��Top=�6Y   $	��120��6q    �� SelectedIndex$ 0��6}   .@�5      �� $
��9600��6   �� 5      $
��4800��6   $
��Left=�6*   $	��118��6E   �� 5      $
��2400��6   $
��Left=�6*   $	��118��6E   5      �� 5   
   -   5        $ cBoxDataBits��5      $
��Left=�6)   $��178,175,0,0q�6D   $	��Top=�6Y   $	��120��6q    �� Text$ 8��6}   $ 0��6�   .@�5      �� $��8��6   �� 5      $��7��6   �� 5      $��6��6   5      �� 5   
   -   5        $ cBoxStopBits��5      $
��Left=�6)   $��178,212,0,0q�6D   $	��Top=�6Y   $	��120��6q   $	 One��6}   $ 0��6�   .@�5      �� $	��One��6   �� 5      $	��Two��6   5      �� 5   
   -   5        $ cBoxParityBits��5      $
��Left=�6+   $��178,249,0,0q�6F   $	��Top=�6[   $	��120��6s   $ 0��6   .@�5      �� $
��None��6   �� 5      $	��Odd��6   �� 5      $
��Even��6   5      �� 5   
   -   5         ��Name$ label1��5      $��COM PORT��6    $
��Left=�63   $��	93,97,0,0q�6N   $	��Top=�6a   $��24��6y   $��71��6�   �� 5    
   $��	BAUD RATE��6   $
��Left=�6$   $��
93,135,0,0q�6?   $	��Top=�6S   �� 5!   
   $��	DATA BITS��6   $
��Left=�6$   $��
93,172,0,0q�6?   $	��Top=�6S   �� 5"   
   $��PARITY BITS��6   $
��Left=�6&   $��
93,248,0,0q�6A   $	��Top=�6U   �� 5#   
   $��	STOP BITS��6   $
��Left=�6$   $��
93,209,0,0q�6?   $	��Top=�6S   �� 5$   
   -   5         ��Name$ 
btnConnect��5$      $��Connect��6%   $
��Left=�67   $��
93,295,0,0q�6R   $	��Top=�6f   $	��205��6~   $��31��6�   6�   5%      5&      