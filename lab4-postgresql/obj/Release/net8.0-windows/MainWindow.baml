   M S B A M L   `   `   `  ���� J  Flab4-postgresql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:lab4_postgresqllab4_postgresql  G(clr-namespace:lab4_postgresql.ViewModelslab4_postgresql.ViewModels       lab4_postgresql.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:lab4_postgresql     >	viewmodel(clr-namespace:lab4_postgresql.ViewModels       � Title$  
MainWindow��$	��450��$	��800�� � DataContext .   (lab4_postgresql.ViewModels.MainViewModel   � 	Resources  �� 
TargetType �� Property �� Value��%/   '�       �� " �.���  � ��
 �����.���  � RowDefinitions �� $��25 ��� $
��0.1* ��� $��* �.+�o� $��0��$	��Top=�$��Center=�
�������$	��3 2q�.@�m� $��Файл��.@�m� $5��/Сохранить сущности в файл�� m� Command �� *FileSaveCommand+m� $��Информация��.@�m� $��Справка�� �� *ShowAboutCommand+� $��1�� � ColumnDefinitions �� �� �� �� �� �� .+��� $��0��$%��Добавить продукт������ *ProductVM.AddProductCommand+�� $��1��$%��Изменить продукт������ * ProductVM.UpdateProductCommand+�� $��2��$#��Удалить продукт������ * ProductVM.RemoveProductCommand+�� $��3��$)��#Добавить категорию������ *CategoryVM.AddCategoryCommand+�� $��4��$)��#Изменить категорию������ *" CategoryVM.UpdateCategoryCommand+�� $��5��$'��!Удалить категорию������ *" CategoryVM.RemoveCategoryCommand+�� $��2��$��0 10 0 0q�.@��� $��Продукты�� �� *	ProductVM+.��&   System.Windows.Controls.DataGrid  	   AutoGenerateColumns$	 False��
   
IsReadOnly$

 True��   CanUserAddRows$ False������ *
Products+ �� UpdateSourceTrigger$ PropertyChanged=� �� IsAsync$
 True�� �� SelectedItem �� *SelectedProduct+$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ProductId+  $ Название��$ *  �� *ProductName+  $ Цена��$ *  �� *Price+  $ Количество��$ *  �� *
Quantity+  $# Номер категории��$ *  �� *
CategoryId+�� $��Категории�� �� *
CategoryVM+.��  $	 False��$

 True��$ False������ *
Categories+$ PropertyChanged=�$
 True�� �� *SelectedCategory+$ PropertyChanged=�   $ 
Номер��$ *  �� *
CategoryId+  $ Название��$ *  �� *CategoryName+