   M S B A M L   `   `   `  ����B  >WPFMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPFMVVM.ViewsWPFMVVM.Views  5           WPFMVVM.Views.EmployeeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPFMVVM.Views     5      .��5	      � $��15,15,81,21q�6     � ColumnDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Employee Management��6   $��0��6/   $��0��6<   $��2��5      $��20(�6(   $
��Bold"�66   $��Center=�6H   �� 5   
   $��Enter Id��6   $��1��5      $��0��6!   �� 5   
   $��
Enter Name��6   $��2��5      $��0��6!   �� 5   
   $��	Enter Age��6   $��3��5       $��0��6!   �� 5!   
   -   5        $��txtId��5!      $��1��5"      $��1��6!   ��5#      ��  �� Path$ CurrentEmployee.Id��� 5$   
   -   5        $��txtName��5$      $��2��5%      $��1��6!   ��5&      �� $ CurrentEmployee.Name��� 5'   
   -   5        $��txtAge��5'      $��3��5(      $��1��6!   ��5)      �� $ CurrentEmployee.Age��� 5+   
    �� Orientation$ 
Horizontal=�6   $��4��5,      $��1��6"   .+�5-      �� -   5        $��btnAdd��5-      $	��ADD��6#   ��61   �� $ SaveCommand��� 5.      -   5        $��	btnSearch��5.      $��SEARCH��6&   ��5/      �� $ SearchCommand��� 50      -   5        $��	btnUpdate��50      $��UPDATE��6&   �� 51      -   5        $��	btnDelete��51      $��DELETE��6&   52      �� 53   
   -   5         ��Name$ txtBlockMessage��53      $��5��6-   $��1��54      ��6$   �� $ Message�&   System.Windows.Controls.DataGrid  55   
   -	   5        $��dgEmployees��55         AutoGenerateColumns$ False��6&   $��5��56      $��1��6    $��0,16,0,-120q�57   K   $��2��6`   ��6   �� $ EmployeesList� �� Mode$ TwoWay=�   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Id��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 auto 5:   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5;   %   �� $ Id�  5<      $ Employee Name��6%   $
	 auto 5=   %   
 5>   %   �� $
 Name�  5?      $ Employee Age��6%   $
	 auto 5@   %   
 5A   %   �� $	 Age�5D      5E      5F      