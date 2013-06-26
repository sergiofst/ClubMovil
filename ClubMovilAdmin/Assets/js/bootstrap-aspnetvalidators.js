/**
* Re-assigns a couple of the ASP.NET validation JS functions to
* provide a more flexible approach
*/
function UpgradeASPNETValidation() {
    // Hi-jack the ASP.NET error display only if required
    if (typeof (Page_ClientValidate) != "undefined") {
        ValidatorUpdateDisplay = NicerValidatorUpdateDisplay;
        //AspPage_ClientValidate = Page_ClientValidate;
        //Page_ClientValidate = NicerPage_ClientValidate;
    }
}

/**
* Extends the classic ASP.NET validation to add a class to the parent span when invalid
*/
function NicerValidatorUpdateDisplay(val) {
  
    if (val.isvalid) {
        $(val).hide();
    } else {
        $(val).show();
    }

    var controlToValidate = document.getElementById(val.controltovalidate);

    var valido = AllValidatorsValid(controlToValidate.Validators);

    if (valido) {
        $(controlToValidate).parent().parent().removeClass("error");
    } else {
        $(controlToValidate).parent().parent().addClass("error");
    }

}

/**
* Extends classic ASP.NET validation to include parent element styling
*/
/*
function NicerPage_ClientValidate(validationGroup) {
    var valid = AspPage_ClientValidate(validationGroup);

    if (!valid) {
        //alert("NicerPage_ClientValidate NotValid: " + $(this));
        // do custom styling etc
        // I added a background colour to the parent object
        //alert("NicerPage_ClientValidate: " & validationGroup);
        //$(this).parent().addClass('invalidField');
    }
}
*/