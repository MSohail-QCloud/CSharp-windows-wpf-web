   M S B A M L   `   `   `  ����G  CNexusPOS-wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NexusPOS_wpfNexusPOS_wpf  5          NexusPOS_wpf.W2NewSale   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:NexusPOS_wpf     5      -   5          N� Title$  	W2NewSale��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $	��320 �6   6+   �� 5      6   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   .+�5   
   � $��0��6   .+�5      �� 
�������$��1q�6(   ._�5      � .+�5      �� $��Bill Number : ��6   $��20(�65   $��20,0,0,0q�6C   6W   �� 5      -   5        $��lblBillnumber��5   *   $��20(�6   6A   �� 5      $��Customer ID : ��6   $��20(�65   $��50,0,0,0q�6C   6W   �� 5      -   5        $��lblCustomerID��5   *   $��20(�6   6A   �� 5      $��Previouse Balance : ��6   $��20(�6;   $��50,0,0,0q�6I   6]   �� 5      -   5        $��lblPreviouseBalance��5   *   $��20(�6   6G   5      5      5!      � 5"   
   $��1��6    � ColumnDefinitions 5#      �� 5$      $	��200 �6#   61   �� 5%      6&   �� 5&      $��50 �6#   60   �� 5'      $	��200 �6#   61   �� 5(      6%   .+�5*      �� $��0��6   $��20(�6$   $��Center=�62   $��Center=�6M   $��
Customer :��6j   6�   �� 5+      -   5        $��combCustomerName��5+   k   $��15(�6   $��Center=�6%   $��Center=�6G   $��3q�6�   $��1��6�   6�   � 5,      $��2��6   $��2q�6#   .+�5-      �� -   5        $��btnAddPerson��5-   %   $��+��6   $��25(�6T   $��2��6d   ���	#FF13E630$
��Bold"�6�   5.      5/      �� 50      $��3��6   $��20(�6$   $��Center=�62   $��Center=�6M   $��Phone :��6j   6~   �� 51      -   5        $��txtPhoneCustomer��51   (   {�.  $��4��6@   $��15(�6P   $��Center=�6^   $
��Left=�6�   $��3,3,80,3q�6�   6�   52      � 53   
   $��2��6    54      �� 55      6%   �� 56      6%   .+�58      �� 
���   �$��0��6)   $��1q�69   ._�59      � $��0��6    5:      �� 5;      6*   �� 5<      6*   �� 5=      6*   �� 5>      6*   �� 5?      $��3* �6(   66   �� 5@      6*   .+�5B      �� $��0��6   $��	New Order��6)   $��Center=�6=   $��Center=�6Z   $��15(�6u   $
��Bold"�6�   6�   � 5C      $��1��6   $��2q�6(   .+�5D      � $��Center=�6$   .+�5E      �� $��Size :��6$   $��15(�65   $
��Bold"�6C   $��5,0,15,0q�6U   6i   �� 5F      $��Width =��6$   $��15(�66   $
��Bold"�6D   $��5,0,5,0q�6V   6i   �� 5G      -   5        $��txtSizeWidth��5G   &   $	��100��6:   $��15(�6F   $��Center=�6T   $
��Left=�6v   6�   �� 5H      $��Length =��6$   $��15(�67   $
��Bold"�6E   6Y   �� 5I      -	   5        $��txtSizeLength��5I   &   $��15(�6;   $��Center=�6I   $
��Left=�6k   $	��100��6�   6�   �� 5J      $��Total Size=��6$   $��15(�6:   $
��Bold"�6H   6\   �� 5K      -
   5        $��txtSizetotal��5K   8   {�.  $��0��6L   $��15(�6U   $��Center=�6c   $
��Left=�6�   $	��100��6�   6�   5L      5M      � 5N      $��2��6   $��2q�6(   .+�5O      � $��Center=�6$   .+�5P      �� $��Item Description :��6$   $��15(�6A   $
��Bold"�6O   $��5,0,15,0q�6a   6u   �� 5Q      -   5        $��txtItemDescription��5Q   4   $��15(�6&   $��Center=�6N   $
��Left=�6p   $	��470��6�   6�   5R      5S      � 5T      $��3��6   $��2q�6(   .+�5U      � $��Center=�6$   .+�5V      �� $��Qty =��6$   $��15(�64   $
��Bold"�6B   $��5,0,5,0q�6T   6g   �� 5W      -   5        $��txtQty��5W   &   $	��120��64   $��15(�6@   $��Center=�6N   $
��Left=�6p   6�   �� 5X      $��Rate =��6$   $��15(�65   $
��Bold"�6C   6W   �� 5Y      -   5        $��txtRate��5Y   &   $	��120��65   $��15(�6A   $��Center=�6O   $
��Left=�6q   6�   �� 5Z      $��Total =��6$   $��15(�66   $
��Bold"�6D   6X   �� 5[      -   5        $��txtTotal��5[   8   {�.  $	��120��6H   $��15(�6T   $��Center=�6b   $
��Left=�6�   6�   5\      5]      � 5^      $��4��6   $��2q�6(    5_      �� 5`      61   �� 5a      61   .+�5c      � $��0��6    5d      �� 5e   "   62   �� 5f   "   62   �� 5g   "   62   .+�5i      � $��Center=�6(   $��0��6E   .+�5j   "   �� $
��Bold"�6(   $��	Labour = ��6:   $��15(�6N   6^   �� 5k   "   -   5        $��txtLabourCharges��5k   *   $	��200��6B   $��2q�6O   $��15(�6Z   $��Center=�6h   $
��Left=�6�   6�   5l      � 5m      $��Center=�6(   $��1��6E   .+�5n   "   �� $
��Bold"�6(   $��	Design = ��6:   $��15(�6N   6^   �� 5o   "   -   5        $��txtDesignCharges��5o   *   $	��200��6B   $��2q�6O   $��15(�6Z   $��Center=�6h   $
��Left=�6�   6�   5p      � 5q      $��Center=�6(   $��2��6E   .+�5r   "   �� $
��Bold"�6(   $��
Positive =��6:   $��15(�6O   6_   �� 5s   "   -   5        $��txtPositiveCharges��5s   *   $��15(�6D   $��Center=�6R   $
��Left=�6t   $	��200��6�   $��2q�6�   6�   5t      5u      � 5v      $��1��6    5w      �� 5x   "   62   �� 5y   "   62   �� 5z   "   62   .+�5|      � $��Center=�6(   $��1��6E   .+�5}   "   �� $
��Bold"�6(   $��Delivery Date :  ��6:   $��15(�6V   6f   (  "System.Windows.Controls.DatePicker  5~   "   -   5        $��dtpickerDeliveryDate��5~   -   $	��195��6I      FirstDayOfWeek$ Saturday=�6U   ��6o   Z� 5      � 5�      $��Center=�6(   $��2��6E   .+�5�   "   �� $
��Bold"�6(   $��Total amount = ��6:   $��15(�6T   6d   �� 5�   "   -   5        $��txtTotalAmount��5�   <   {�.  $��15(�6R   $��Center=�6`   $
��Left=�6�   $	��200��6�   $��2q�6�   6�   5�      5�      5�      � 5�      $��5��6   .+�5�      �� -   5        $��SaveItem��5�   !   $
��Save��6H   $��Center=�6W   $��Right=�6r   $��0,0,20,0q�6�   $��15(�6�   $
��Bold"�6�   $	��100��6�   6�   �� 5�      -   5        $��
btnRefresh��5�   !   $��Refresh��6L   $��Center=�6^   $��Center=�6y   $��0,0,20,0q�6�   $��15(�6�   $
��Bold"�6�   $	��100��6�   6�   5�      5�      5�      �� 5�      
���   �$��1��6)   $��1q�69   ._�5�      � $��2��6   5�      5�      5�      � 5�   
   -   5        $��Datagridbill��5�   '   $��3��6   $��2q�6   .+�5�      &   System.Windows.Controls.DataGrid  -   5        $��datagridBill��5�   #  $��15(�6      RowHeaderWidth$ 40Q�6%   $   HorizontalScrollBarVisibility$
 Auto=�6:      CanUserAddRows .  $��Stretch=�6v   $��Stretch=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $	��Top=�6�      AlternatingRowBackground
 �����	   AutoGenerateColumns	 .  $��2q�67  
   Columns
 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width$ 20 6)      Header$  ��6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$	 DEl�6Q     5�      $ 40 6)   $ ID��6\    64   �� $ detail_bill_id�6\     5�         
FontWeight$
 Bold"�6H   $	 Qty��6Z    6*   �� $	 Qty�6Z     5�      $	 250 6)   $ Item Description��6^    65   �� $ ItemDescription�6^     5�      $ Width��6M    6*   �� $ 	SizeWidth�6M     5�      $ Length��6*    6;   �� $ 
SizeLength�  5�      $ 
Total Size��6*    6?   �� $ 	TotalSize�  5�      $
 Rate��6*    69   �� $
 Rate�  5�      $ Total��6*    6:   �� $ Total�  5�      $ Labour Charges��6*    6B   �� $ LabourCharges�  5�      $ Design Charges��6)    6B   �� $ DesignCharges�  5�      $ Positive Charges��6*    6D   �� $ PositiveCharges�  5�      $	 120 6)   $ Total Amount��67    6N   �� $ totalamount�  5�      $	 200 6)   $ Delivery Date��66    6N   �� $ DeliveryPromiseDate�5�      5�      � 5�   
   $��4��6   .+�5�      � $��Center=�6   $��Right=�63   .+�5�      �� $��SubTotal = ��6   $��15(�6.   6>   �� 5�      -   5        $��txtSubTotal��5�   ,   {�.  $��15(�6?   $	��150��6M   $��Right=�6Y   $��Center=�6|   6�   �� 5�      $��Discount = ��6   $��15(�6.   6>   �� 5�      -   5        $��txtDiscount��5�   �   $��0��6@   $��Right=�6I   $��Center=�6l   $��15(�6�   $	��150��6�   6�   �� 5�      $��GrandTotal = ��6   $��15(�60   6@   �� 5�      -   5        $��txtGrandtotal��5�      $��15(�6Z   $	��150��6h   $��0,0,10,0q�6t   $��Right=�6�   {�.  $��Center=�6�   6�   5�      5�      � 5�   
   $��5��6   .+�5�      � $��Center=�6   $��Right=�63   .+�5�      �� $��
Advance = ��6   $��15(�6-   6=   �� 5�      -   5        $��txtAdvancPaid��5�      $��15(�6X   $	��150��6f   $��Right=�6r   $��Center=�6�   6�   �� 5�      $��Remaining = ��6   {�.  $��15(�6A   6Q   �� 5�      -   5        $��txtremainig��5�   |   {�.  $��0��6,   $��Right=�65   $��Center=�6Z   $��15(�6�   $	��150��6�   6�   �� 5�      $��Remaining Balance = ��6   {�.  $��15(�6I   6Y   �� 5�      -   5        $��txtremainingBalance��5�   r   {�.  $��Right=�6-   $��Center=�6P   $��15(�6�   $	��150��6�   6�   �� 5�      $��Add Reminder��6   $��10,0,0,0q�60   $��15(�6B   6R   �� 5�      -   5        $��ChkboxPrintSlip��5�       d� 	IsChecked$
 TrueY�62   $��15(�6C   $��10,0,0,0q�6Q   $��
Print Slip��6c   $��Center=�6x   $��Center=�6�   6�   �� 5�      -   5        $��btnGenerateBill��5�   R   $��Generate Bill��6   $��15(�61   $��	10,0,10,0q�6?   6�   5�      5�      5�      5�      