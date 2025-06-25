var myCapId = "REC25-00000-001ET";
var myUserId = "ADMIN";
var eventName = "";
showDebug = true;
/* TEST  */  var eventName = "SCRIPT_TEST";
/* CTRCA */  //var eventName = "ConvertToRealCapAfter";
/* ASA   */  //var eventName = "ApplicationSubmitAfter";
/* ASIUA */  //var eventName = "ApplicationSubmitAfter";
/* WTUA  */  //var eventName = "WorkflowTaskUpdateAfter";  wfTask = "Application Review"; wfProcess = "XX"; wfComment = "XX";  wfStatus = "Pending";  wfDateMMDDYYYY = "01/27/2015";
/* IRSA  */  //var eventName = "InspectionResultSubmitAfter"; inspId=0;  inspType="Roofing"; inspResult="Failed"; inspResultComment = "Comment"; 
/* ISA   */  //var eventName = "InspectionScheduleAfter"; inspType = "Roofing";
/* PRA   */  //var eventName = "PaymentReceiveAfter";

var useProductInclude = true; //  set to true to use the "productized" include file (events->custom script), false to use scripts from (events->scripts)
var useProductScript = true;  // set to true to use the "productized" master scripts (events->master scripts), false to use scripts from (events->scripts)
var runEvent = true; // set to true to simulate the event and run all std choices/scripts for the record type.

/* master script code don't touch */ aa.env.setValue("EventName",eventName); var vEventName = eventName;  var controlString = eventName;  var tmpID = aa.cap.getCapID(myCapId).getOutput(); if(tmpID != null){aa.env.setValue("PermitId1",tmpID.getID1());  aa.env.setValue("PermitId2",tmpID.getID2());  aa.env.setValue("PermitId3",tmpID.getID3());} aa.env.setValue("CurrentUserID",myUserId); var preExecute = "PreExecuteForAfterEvents";var documentOnly = false;var SCRIPT_VERSION = 3.0;var useSA = false;var SA = null;var SAScript = null;var bzr = aa.bizDomain.getBizDomainByValue("MULTI_SERVICE_SETTINGS","SUPER_AGENCY_FOR_EMSE"); if (bzr.getSuccess() && bzr.getOutput().getAuditStatus() != "I") {  useSA = true;   SA = bzr.getOutput().getDescription(); bzr = aa.bizDomain.getBizDomainByValue("MULTI_SERVICE_SETTINGS","SUPER_AGENCY_INCLUDE_SCRIPT");  if (bzr.getSuccess()) { SAScript = bzr.getOutput().getDescription(); } }if (SA) { eval(getScriptText("INCLUDES_ACCELA_FUNCTIONS",SA,useProductScript)); eval(getScriptText("INCLUDES_ACCELA_GLOBALS",SA,useProductScript)); /* force for script test*/ showDebug = true; eval(getScriptText(SAScript,SA,useProductScript)); }else { eval(getScriptText("INCLUDES_ACCELA_FUNCTIONS",null,useProductScript)); eval(getScriptText("INCLUDES_ACCELA_GLOBALS",null,useProductScript)); } eval(getScriptText("INCLUDES_CUSTOM",null,useProductInclude));if (documentOnly) { doStandardChoiceActions2(controlString,false,0); aa.env.setValue("ScriptReturnCode", "0"); aa.env.setValue("ScriptReturnMessage", "Documentation Successful.  No actions executed."); aa.abortScript(); }var prefix = lookup("EMSE_VARIABLE_BRANCH_PREFIX",vEventName);var controlFlagStdChoice = "EMSE_EXECUTE_OPTIONS";var doStdChoices = true;  var doScripts = false;var bzr = aa.bizDomain.getBizDomain(controlFlagStdChoice ).getOutput().size() > 0;if (bzr) { var bvr1 = aa.bizDomain.getBizDomainByValue(controlFlagStdChoice ,"STD_CHOICE"); doStdChoices = bvr1.getSuccess() && bvr1.getOutput().getAuditStatus() != "I"; var bvr1 = aa.bizDomain.getBizDomainByValue(controlFlagStdChoice ,"SCRIPT"); doScripts = bvr1.getSuccess() && bvr1.getOutput().getAuditStatus() != "I"; } function getScriptText(vScriptName, servProvCode, useProductScripts) { if (!servProvCode)  servProvCode = aa.getServiceProviderCode(); vScriptName = vScriptName.toUpperCase(); var emseBiz = aa.proxyInvoker.newInstance("com.accela.aa.emse.emse.EMSEBusiness").getOutput(); try {  if (useProductScripts) {   var emseScript = emseBiz.getMasterScript(aa.getServiceProviderCode(), vScriptName);  } else {   var emseScript = emseBiz.getScriptByPK(aa.getServiceProviderCode(), vScriptName, "ADMIN");  }  return emseScript.getScriptText() + ""; } catch (err) {  return ""; }}logGlobals(AInfo); if (runEvent && typeof(doStandardChoiceActions) == "function" && doStdChoices) try {doStandardChoiceActions(controlString,true,0); } catch (err) { logDebug(err.message) } if (runEvent && typeof(doScriptActions) == "function" && doScripts) doScriptActions(); var z = debug.replace(/<BR>/g,"\r");  /*AAPrintWtihLineBreak(z);*/
logDebug("---RUNNING TEST CODE")
//
// User code goes here
//
aa.print("Starting of the dance");



var q = "SELECT * FROM B1PERMIT B WHERE SERV_PROV_CODE = ? and B1_PER_ID3 ='theid3' and B1_PER_ID1 ='theid1' and B1_PER_ID2 ='theid2' ";

var fees_to_be_paidJson = _getScriptText("estopConversionFeesToBePaid", null, false);
var fees_to_be_paidJson_obj = eval(fees_to_be_paidJson);

var feecnt = 0;
for (feecnt in fees_to_be_paidJson_obj)
{
    aa.print("Permit to be paid "+fees_to_be_paidJson_obj[feecnt]);
    var perparmid1 = fees_to_be_paidJson_obj[feecnt].split("-");
    var qtemp = q.replace("theid3",perparmid1[3]);
    qtemp = qtemp.replace("theid1",perparmid1[1]);
    qtemp = qtemp.replace("theid2",perparmid1[2]);
    aa.print("The Permit SQL ");
    aa.print(qtemp);
    aa.print(q);

    var recordsResult =  aa.db.select(qtemp, [aa.getServiceProviderCode()]);
    var records = null;
    var paymentAmount = 500;
    var payDate =  new Date();
    var infoLog = [];
    
    payDate = Date.now();
    aa.print(payDate);
    
    if (!recordsResult.getSuccess()) 
    {
        // Error getting records back
        aa.print("Problem in selectRecords(): " + recordsResult.getErrorMessage());
        aa.print("Problem in selectRecords(): " );
    
    }
    else 
    {
        var altid = "";
        var applyPayment = true;
    
        records = recordsResult.getOutput();
        aa.print("Number of Recordos returnd "+records.size());
        var rec = records.toArray();
        for (var i in rec) 
        {
            var q2 = "select c.INVOICE_AMOUNT amt from F4FEEITEM a ";
            q2+= "inner join X4FEEITEM_INVOICE b ";
            q2+="on a.B1_PER_ID1=b.B1_PER_ID1 and a.B1_PER_ID2 = b.B1_PER_ID2 and a.B1_PER_ID3 = b.B1_PER_ID3 ";
            q2+="inner join F4INVOICE c on b.INVOICE_NBR = c.INVOICE_NBR ";
            q2+="WHERE a.SERV_PROV_CODE = ? and a.B1_PER_ID1='theid1' and a.B1_PER_ID2 = 'theid2' and a.B1_PER_ID3 = 'theid3'"
    
            aa.print(q2);
            
            var q2temp = q2.replace("theid3",perparmid1[3]);
            q2temp = q2temp.replace("theid1",perparmid1[1]);
            q2temp = q2temp.replace("theid2",perparmid1[2]);

            aa.print("The Invoice SQL ");
            aa.print(q2temp);
            aa.print(q2);
            var invoiceres =  aa.db.select(q2temp, [aa.getServiceProviderCode()]);
            if (invoiceres.getSuccess()) 
            {
                var records2 = null;
                records2 = invoiceres.getOutput();
    
                var rec2 = records2.toArray();
    
                for (var z in rec2)
                {
                    theamt = rec2[z].get("amt");
                }
    
    
                aa.print("The amt  "+ theamt);
                altId = rec[i].get("B1_ALT_ID");
                capId = aa.cap.getCapID(altId).getOutput();
    
                aa.print("altid "+capId);
                aa.print(rec[i].get("B1_PER_ID3"));
                if (capId)
                {
                    aa.print(capId.getCustomID());
                    feeItems = getFeeItemsByCapId(capId);
                    aa.print("Got " + feeItems.length + " fee items for record ID " + String(capId));
                    paymentAmount = parseInt(theamt);// / 100;
                    aa.print("The paymentamount "+paymentAmount);
                    var payment = makePayment(capId, paymentAmount, "03/03/2025");
                    /* */
                    if (applyPayment) 
                    {
                        var paidFeesOut = getPaidFeeItems(capId);
                        var paidFees = {};
                        for (var index = 0; index < paidFeesOut.length; index++) 
                        {
                            if (paidFeesOut[index].getFeeAllocation() == 0) 
                            {
                                continue;
                            }
                            var feeSeqNumber = paidFeesOut[index].getFeeSeqNbr();
                            // If there is two payments on the same fee items make sure to
                            // consolidate them
                            if (paidFees[feeSeqNumber]) 
                            {
                                paidFees[feeSeqNumber] += paidFeesOut[index].getFeeAllocation();
                            } 
                            else 
                            {
                                paidFees[feeSeqNumber] = paidFeesOut[index].getFeeAllocation();
                            }
                        }
                        // Sort ascending
                        feeItems.sort(function(a, b) {
                            return a.getFeeSeqNbr() - b.getFeeSeqNbr();
                        });
    
                        // Fee items to pay
                        // Fee amount we are paying
                        // Invoice number the fee belongs to
                        var feeItemsArr = [];
                        var feeAllocArr = [];
                        var invoicesArr = [];
                        var remainingAmount = paymentAmount;
                        for (var i = 0; i < feeItems.length; i++) 
                        {
                            var feeSequenceNumber = feeItems[i].getFeeSeqNbr();
                            var feeAmount = feeItems[i].getFee();
                            var feeItemStatus = feeItems[i].getFeeitemStatus();
                            var feeInvoiceNumber = feeItems[i].getInvoiceNbr();
                            // If there is a paid fee subtract it from this fee
                            if (paidFees[feeSequenceNumber]) 
                            {
                                feeAmount = feeAmount - paidFees[feeSequenceNumber];
                            }
                            // if the fee amount is 0 (will mostly happen in case the paid
                            // amount in full)
                            // or if the fee item status is not INVOICED
                            // then we skip this item
                            if (feeAmount <= 0 || feeItemStatus != "INVOICED") 
                            {
                                continue;
                            }
                            // Make sure we still have remainingAmount to pay this fee,
                            // otherwise pay as much as we can
                            if (remainingAmount < feeAmount) 
                            {
                                feeAmount = remainingAmount;
                            }
                            feeItemsArr.push(feeSequenceNumber);
                            invoicesArr.push(feeInvoiceNumber);
                            feeAllocArr.push(feeAmount);
                            remainingAmount -= feeAmount;
                            // Update paid fees
                            if (paidFees[feeSequenceNumber]) 
                            {
                                paidFees[feeSequenceNumber] = paidFees[feeSequenceNumber] + feeAmount;
                            } 
                            else 
                            {
                                paidFees[feeSequenceNumber] = feeAmount;
                            }
                            
                            if (remainingAmount == 0) 
                            {
                                break;
                            }
                        }
                        var applyResult = aa.finance.applyPayment(capId, payment, feeItemsArr, invoicesArr, feeAllocArr, "Paid", "Paid", "0");
                        if (!applyResult.getSuccess()) 
                        {
                            throw applyResult.getErrorMessage();
                        }
                        aa.print("Applied payment successfully for record ID " + String(capId));
                
                        var receiptResult = aa.finance.generateReceipt(capId, aa.date.getCurrentDate(), payment.getPaymentSeqNbr(), payment.getCashierID(), null);
                        if (!receiptResult.getSuccess()) 
                        {
                            throw receiptResult.getErrorMessage();
                        }
                        
    
                    }  // applyPayment
                    /* */
                }
            }
            else 
            {
                    // Error getting records back
                aa.print("Problem in selectRecords(): " + invoiceres.getErrorMessage());
                aa.print("Problem in selectRecords(): " );
    
            }
    
        }
    }

}  // for feecnt in fees_to_be_padJson



    //#region utilityCdoe
 
    function explore(objExplore) {
        logDebug("Methods:")
        for (x in objExplore) {
            if (typeof(objExplore[x]) == "function") {
                logDebug("<font color=blue><u><b>" + x + "</b></u></font> ");
                logDebug("   " + objExplore[x] + "<br>");
            }
        }
        logDebug("");
        logDebug("Properties:")
        for (x in objExplore) {
            if (typeof(objExplore[x]) != "function") logDebug("  <b> " + x + ": </b> " + objExplore[x]);
        }
    }
   
    function props(objExplore) {
        aa.print("Properties:")
        aa.print("Properties:")
        for (x in objExplore) {
            if (typeof(objExplore[x]) != "function") {
                aa.print("  <b> " + x + ": </b> " + objExplore[x]);
                aa.print( x + " : " + objExplore[x]);
            }  
        }
    }
   
    function aaExplore(objExplore) {
        aa.print("Methods:")
        for (x in objExplore) {
            if (typeof(objExplore[x]) == "function") {
                aa.print(x);
                aa.print(objExplore[x]);
            }
        }
        aa.print("");
        aa.print("Properties:")
        for (x in objExplore) {
            if (typeof(objExplore[x]) != "function") {
                aa.print(x + " : " + objExplore[x]);
            }
        }
    }
 //#endregion
 
 //#region public methds
 function getFeeItemsByCapId(capId) {
    var feeItems = aa.finance.getFeeItemInvoiceByCapID(capId, null);
    if (!feeItems.getSuccess()) {
        throw feeItems.getErrorMessage();
    }
    return feeItems.getOutput();
}

function getFeeItemsByInvoice(invoiceNumber) {
    var invoiceFeeItems = aa.invoice.getFeeItemInvoiceByInvoiceNbr(invoiceNumber);
    if (!invoiceFeeItems.getSuccess()) {
        throw invoiceFeeItems.getErrorMessage();
    }
    return invoiceFeeItems.getOutput();
}

function getPaidFeeItems(capId) {
    var paidFeeItems = aa.finance.getPaymentFeeItems(capId, null);
    if (!paidFeeItems.getSuccess()) {
        throw paidFeeItems.getErrorMessage();
    }
    return paidFeeItems.getOutput();
}

function getInvoice(capId, invoiceNumber) {
    var invoice = aa.cashier.getInvoice(capId, invoiceNumber);
    if (!invoice.getSuccess()) {
        throw invoice.getErrorMessage();
    }
    return invoice.getOutput();
}

function makePayment(capId, paymentAmount, paymentDate) {
    var paymentModel = aa.finance.createPaymentScriptModel();
    paymentModel.setAuditDate(aa.date.getCurrentDate());
    paymentModel.setAuditStatus("A");
    paymentModel.setCapID(capId);
    paymentModel.setCashierID("ADMIN");
    paymentModel.setPaymentSeqNbr(paymentModel.getPaymentSeqNbr());
    paymentModel.setPaymentAmount(0);
    aa.print("The payment amount "+paymentAmount);
    paymentModel.setAmountNotAllocated(0);
    paymentModel.setPaymentChange(0);

    paymentModel.setPaymentComment("Paid Through Bill2Pay");
    aa.print(aa.date.getCurrentDate);
    paymentModel.setPaymentDate(aa.date.parseDate(paymentDate));
    paymentModel.setPaymentMethod("Lockbox");
    paymentModel.setPaymentStatus("Paid");
    var paymentSequenceNumber = aa.finance.makePayment(paymentModel);
    if (!paymentSequenceNumber.getSuccess()) {
        aa.print(paymentSequenceNumber.getErrorMessage());
        throw paymentSequenceNumber.getErrorMessage();
    }

    var paymentSequenceNumber = paymentSequenceNumber.getOutput();
    logInfo("Made payment successfully for record ID " + String(capId) + " payment sequence# " + paymentSequenceNumber);
    
    var payment = aa.finance.getPaymentByPK(capId, paymentSequenceNumber, "ADMIN");
    if (!payment.getSuccess()) {
        throw payment.getErrorMessage();
    }
    return payment.getOutput();
}

function getInvoicesBalance(capId) {
	var invoices = aa.finance.getInvoiceByCapID(capId, null);
	if (!invoices.getSuccess()) {
        throw invoices.getErrorMessage();
    }
	invoices = invoices.getOutput();
	logInfo("Renewal record " + String(capId) + " has " + invoices.length + " Invoices");
	
	var totalDue = 0;
	for (var i = 0; i < invoices.length; i++) {
		var invoiceNumber = invoices[i].getCustomizedNbr();
		var invoiceBalance = parseFloat(invoices[i].getInvoiceModel().getBalanceDue());
		totalDue += invoiceBalance;
		logInfo("Invoice# " + invoiceNumber + " has a balance of " + invoiceBalance);
	}
	
	return totalDue;
}


function getApplication(appNum) {
	var getCapResult = aa.cap.getCapID(appNum);
	if (getCapResult.getSuccess())
		return getCapResult.getOutput();
    return null;
}


function formatDate(date) {
    if (date.getClass() && date.getClass().toString().equals("class com.accela.aa.emse.util.ScriptDateTime")) {
        return date.getYear() + "-" + (date.getMonth() < 10 ? "0" : "") + date.getMonth() + "-" + (date.getDayOfMonth() < 10 ? "0" : "") + date.getDayOfMonth();
    }
    return "";
}

function arrayToString(arr) {
    return "[" + (arr ? arr.join("|") : "") + "]";
}

// returns the result as proper JSON structure when called by construct API
function buildResultStructure(value) {
	if (value) {
		if (Object.prototype.toString.call(value) == "[object Object]") {
			value = buildObjectStructure(value);
		} else if (Object.prototype.toString.call(value) === '[object Array]') {
			value = buildArrayStructure(value);
		}
	}
	return value;
}

function buildObjectStructure(obj) {
	var table = aa.util.newHashMap();
	for ( var p in obj) {
		if (obj.hasOwnProperty(p)) {
			var value = obj[p];
			table.put(obj[p], buildResultStructure(value));
		}
	}
	return obj;
}

function buildArrayStructure(arr) {
	var arrList = aa.util.newArrayList();
	for (var i = 0; i < arr.length; i++) {
		arrList.add(buildResultStructure(arr[i]));
	}
	return arrList;
}

function logInfo(s) {
	infoLog.push(s);
}

function logWarning(s) {
	warningLog.push(s);
}

function _getScriptText(vScriptName, servProvCode, useProductScripts)
{
// AAPrintWtihLineBreak("The start ");
    // aa.sendMail("no_reply@accela.com", "kelly@grayquarter.com", "", "Entering _getScriptText", "Kelly J");
    if (!servProvCode)
    {
        servProvCode = aa.getServiceProviderCode();
    }

    vScriptName = vScriptName.toUpperCase();
    // vScriptName = "DC_ACTIVE_CON_CASE_PEOPLE";

    var emseBiz = aa.proxyInvoker.newInstance("com.accela.aa.emse.emse.EMSEBusiness").getOutput();
    try 
    {
        if (useProductScripts) 
        {
            var emseScript = emseBiz.getMasterScript(aa.getServiceProviderCode(), vScriptName);
        } 
        else 
        {
            var emseScript = emseBiz.getScriptByPK(aa.getServiceProviderCode(), vScriptName, "ADMIN");
        }

        // AAPrintWtihLineBreak("The END ");
        // aa.sendMail("no_reply@accela.com", "kelly@grayquarter.com", "", "Debug PreSend", emseScript);
        // aa.sendMail("no_reply@accela.com", "kelly@grayquarter.com", "", "Leaving _getScriptText", "Kelly J");
        return emseScript.getScriptText() + "";
        //AAPrintWtihLineBreak("REturning "+emseScript.getScriptText() + "");

    } 
    catch (err) 
    {
        AAPrintWtihLineBreak("Critical Error "+err);
        // return "Critical Error "+err;
    }
}



//#endregion