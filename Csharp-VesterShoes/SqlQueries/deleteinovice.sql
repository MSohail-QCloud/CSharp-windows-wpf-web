select * from tblLedger where EventID=171

delete tblDetailInvoice where InvoiceID=171
delete tblMasterInvoice where InvoiceID=171
delete tblLedger where EventID=171
update tblOrders set jobStates=7 where Invoiceid=171