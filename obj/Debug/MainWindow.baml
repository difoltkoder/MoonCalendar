   M S B A M L   `   `   `  ����G  Cmooncalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:mooncalendarmooncalendar  5   	       mooncalendar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:mooncalendar     5   	     � Title$  
MainWindow��5   	   $	��560��6   $	��850��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   ���	#FF060E21.+�5      �� -   5         ��Name$
 Home��5      $��Календарь��6#   $��35��68   $	��100��6D   $��5,5,5,5q�6S   6y   �� 5      -   5        $ Calendar��5      $��Основное��6'   $��35��6;   $	��100��6G   $��5,5,5,5q�6V   6�   �� 5      -   5        $ Zametki��5      $��Заметки��6&   $��35��69   $	��100��6E   $��5,5,5,5q�6T   6}   �� 5      -   5        $ 
Randomazer��5      $��Гадание��6)   $��35��6<   $	��100��6H   $��5,5,5,5q�6W   6h   5       � 5   
   -   5          �Name$ Myframe��5   "   
����  �$��1��63     � NavigationUIVisibility$ Hidden=�6@   5      �� 5   
   -   5         ��Name$ 	TextBox12��5      $��35(�6'   $E��?Вас приветствует лунный календарь��65   $��Center=�6_   $��Center=�6z   $��1��6�   
�������5      5      5      