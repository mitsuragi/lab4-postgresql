   M S B A M L   `   `   `  ����J  Flab4-postgresql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:lab4_postgresql.Viewslab4_postgresql.Views  5   	   *    $lab4_postgresql.Views.CategoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:lab4_postgresql.Views     5   	     � Title$  Категория��5   	   $	��200��6   $	��300��6(   .��5	      � $��10q�6    � 	Resources 5
   
    �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 70��6*   �� 5       � ��$ 25��6+   �� 5       � ��$ 5,0,0,0q�6+   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��1��6    .��6-   &$Название категории:6B   �� 5   
   $��1��6   $��1��6"   $
��auto��6/   ��6<   �� *CategoryName+�� 5   
   $��2��6   $��2��6)    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��10 10q�6k   .+�5       �� -   5        $��okButton��5        �� 	IsDefault$
 True��6%   .��6K   ОК6O   �� 5!      -   5        $��cancelButton��5!      	 �� IsCancel$
	 True��6)   .��69   Отмена6A   5"      5$      5%      