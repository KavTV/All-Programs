   M S B A M L   `   `   `  ����[  WSubnetteren over alle subnettere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Subnetteren_over_alle_subnettere Subnetteren_over_alle_subnettere  5   	   1    +Subnetteren_over_alle_subnettere.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   :local.clr-namespace:Subnetteren_over_alle_subnettere  5   	     � Title$  
MainWindow��5
   	   $	��450��6   $��418.4��6)   .��5      � .+�5   
   �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Images/The Matrix.gif��6   $��-67,-155,-108,-123q�6I   �� 5   
   $��IP Addresse��6   $
��Left=�6&   $��	40,30,0,0q�6A   $	��Top=�6T   ���	#DDFFFFFF6l   �� 5   
   -   5         ��Name$	 IP1��5      $��	40,56,0,0q�6    �� 	MaxLength$ 3��62    �� TextWrapping$
 Wrap=�6@   $�� ��6T   $��28��6�   $	��Top=�6�   $
��Left=�6�   $��72��6�   $��14(�6	  
������� �� 
CaretBrush �	#FF27C6206*  �� 5   
   -   5        $	 IP2��5      $��
129,56,0,0q�6   $ 3��63   $
 Wrap=�6A   $�� ��6U   $��28��6�   $	��Top=�6�   $
��Left=�6�   $��72��6�   
�������$��14(�6   �	#FF27C620 �� SelectionBrush �	#FF27C6206B  �� 5   
   -   5        $	 IP3��5      $ 3��6   $��
219,56,0,0q�6-   $
 Wrap=�6A   $�� ��6U   $��28��6�   $	��Top=�6�   $
��Left=�6�   $��72��6�   
�������$��14(�6   �	#FF27C620 �	#FF27C6206B  �� 5   
   -   5        $	 IP4��5      $ 3��6   $��
310,56,0,0q�6-   $
 Wrap=�6A   $�� ��6U   $��28��6�   $	��Top=�6�   $
��Left=�6�   $��72��6�   
�������$��14(�6   �	#FF27C620 �	#FF27C6206B  �� 5   
   -   5        $ Host1��5      $��
40,120,0,0q�6!   $
 Wrap=�65   $��32��6�   $	��Top=�6�   $
��Left=�6�   $	��108��6�   
�������$��14(�6   �	#FF27C620 �	#FF27C62063  �� 5   
   -   5         ��Name$ AddList��5      $��Tilføj��6"   $��171,120,0,0q�63   $��32��6^   $	��Top=�6j   $
��Left=�6�   $��92��6�   ��6�   Z� ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 	#FF793434��6#    � Offset$ 0Q�65   � 5      $	
 Red��6#   $ 1Q�6/   5      5      �� 5   
   -   5        $ 
RegnUdKnap��5      $��Regn ud��6%   $��171,156,0,0q�67   $
��Left=�6e   $��92��6�   $��30��6�   $	��Top=�6�   ��6�   Z� ��5      �� 5      $ 0.5,1&�6&   $	 0.5,0&�67   .��5       � $	
 Red��6#   $ 0Q�6/   � 5!      $
 	#FF793434��6#   $ 1Q�65   5"      5$      �� 5%   
   $
��Host��6   $
��Left=�6   $��	40,90,0,0q�6:   $	��Top=�6M   ���	#DDFFFFFF6e   �� 5&   
   -   5        $ 
Resultater��5&      $��
40,196,0,0q�6&   $
 Wrap=�6:    �� 
IsReadOnly . $��13(�6`   $	��224��6n   $	��Top=�6{   $
��Left=�6�   $	��196��6�   
�������.��6�    5'      �� 5(       �� Color$ 	#FF0078D7��6"    �� Opacity$ 0Q�64   .��5)   &    5*      �� 5+      $ 	#FF673AB7��6"   $ 0Q�64   .��5,   "   5-      �� 5.   
   $��.��6   $��Right=�6   $��0,0,664.6,314q�68   $��Bottom=�6O   $��48��6j   $��15��6v   $��20(�6�   �� 5/   
   $��.��6   $��Right=�6   $��0,0,577.6,314q�68   $��Bottom=�6O   $��48��6j   $��13��6v   $��20(�6�   �� 50   
   $��.��6   $��Right=�6   $��0,0,483.6,330q�68   $��Bottom=�6O   $��32��6j   $��16��6v   $��20(�6�   54      55      