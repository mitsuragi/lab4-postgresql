   M S B A M L   `   `   `  ����J  Flab4-postgresql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:lab4_postgresql.Viewslab4_postgresql.Views  5   	   G(clr-namespace:lab4_postgresql.ViewModelslab4_postgresql.ViewModels  5   	   )    #lab4_postgresql.Views.ProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:lab4_postgresql.Views     5   	   >	viewmodel(clr-namespace:lab4_postgresql.ViewModels     5   	     � Title$  Продукт��5	   	   $	��200��6   $	��300��6&    � 	Resources 5
         CategoriesSource��%   &	        �� 5   
   6   5      .��5      � $��10q�6    5   
    �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 70��6*   �� 5       � ��$ 25��6+   �� 5       � ��$ 5,0,0,0q�6+   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   .+�5$   
   �� $��0��6   $��0��6    .��6-   Название:68   �� 5%   
   $��1��6   $��0��6"   ��6/   �� *ProductName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5'   
   $��0��6   $��1��6    .��6-   	Цена:64   �� 5(   
   $��1��6   $��1��6"   ��6/   �� *Price+$ PropertyChanged=��� 5*   
   $��0��6   $��2��6    .��6-   Количество:6:   �� 5+   
   $��1��6   $��2��6"   ��6/   �� *
Quantity+$ PropertyChanged=��� 5-   
   $��0��6   $��3��6    .��6-    Номер категории:6?   �� 5.   
   $��1��6   $��3��6#    �� DisplayMemberPath$ CategoryName��50      	 �� SelectedValuePath$	 
CategoryId��51      ��5/      �� 
 �� Source#
 [   �� SelectedValue 52      �� *
CategoryId+ �� Mode$ TwoWay=�$ PropertyChanged=��� 54   
   $��0��6   $��2��6%   $��4��69    �� Orientation$ 
Horizontal=�6F   $��Right=�6_   $��10 10q�6{   .+�55      �� -   5        $��okButton��55       �� 	IsDefault$
 True��6%   .��6K   Добавить6U   �� 56      -   5        $��cancelButton��56       �� IsCancel$
 True��6)   .��69   Отмена6A   57      58      59      