   M S B A M L   `   `   `  ����J  Flab4-postgresql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:lab4_postgresqllab4_postgresql  5   	   G(clr-namespace:lab4_postgresql.ViewModelslab4_postgresql.ViewModels  5   	        lab4_postgresql.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:lab4_postgresql     5   	   >	viewmodel(clr-namespace:lab4_postgresql.ViewModels     5   	     � Title$   ��5	   	   $	��450��6   $	��800��6    � DataContext 5
      .   (lab4_postgresql.ViewModels.MainViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value��%T   '�       �� 5   
   " �6   .�5      ��  � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $
��0.1* �6   �� 5      $��* �6   .+�5   
   o� $��0��6   $	��Top=�6   $��Center=�64   
�������$	��3 2q�6m   .@�5      m� $��Файл��6   .@�5      m� $5��/Сохранить сущности в файл��6    m� Command 6>   �� *FileSaveCommand+5      m� 5      $��Информация��6   .@�5      m� $��Справка��6    6,   �� *ShowAboutCommand+m� 5      $<��6Отображать справку при входе?��6    m� IsCheckable$
 True��5      	 m� 	IsChecked	 5       �� *ShowStartupMessage+
 �� Mode$
 TwoWay=� 5!      �� *SwitchShowStartupCommand+5"      5#      � 5$   
   $��1��6    � ColumnDefinitions 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      .+�5-      �� $��0��6   $%��Добавить продукт��6%   ��6@   �� *ProductVM.AddProductCommand+�� 5.      $��1��6   $%��Изменить продукт��6%   ��6@   �� * ProductVM.UpdateProductCommand+�� 5/      $��2��6   $#��Удалить продукт��6%   ��6?   �� * ProductVM.RemoveProductCommand+�� 50      $��3��6   $)��#Добавить категорию��6%   ��6B   �� *CategoryVM.AddCategoryCommand+�� 51      $��4��6   $)��#Изменить категорию��6%   ��6B   �� *" CategoryVM.UpdateCategoryCommand+�� 52      $��5��6   $'��!Удалить категорию��6%   ��6A   �� *" CategoryVM.RemoveCategoryCommand+53      �� 54   
   $��2��6   $��0 10 0 0q�6"   .@�55      �� $��Продукты��6    6(   �� *	ProductVM+.��56      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6      
IsReadOnly$
 True��58         CanUserAddRows$ False��59      ��57      �� *
Products+ �� UpdateSourceTrigger$ PropertyChanged=� �� IsAsync$
 True�� �� SelectedItem 5:      �� *SelectedProduct+$ PropertyChanged=�   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *	ProductId+  5=      $ Название��6-   $ * 6?    6I   �� *ProductName+  5>      $ Цена��6-   $ * 6;    6E   �� *Price+  5?      $ Количество��6-   $ * 6A    6K   �� *
Quantity+  5@      $# Номер категории��6-   $ * 6F    6P   �� *
CategoryId+5B      5C      �� 5D      $��Категории��6    6)   �� *
CategoryVM+.��5E        $ False��6   $
 True��5G      $ False��5H      ��5F      �� *
Categories+$ PropertyChanged=�$
 True�� 5I      �� *SelectedCategory+$ PropertyChanged=� 5J        5K      $ 
Номер��6-   $ * 6<    6F   �� *
CategoryId+  5L      $ Название��6-   $ * 6?    6I   �� *CategoryName+5N      5O      5P      5Q      5R      