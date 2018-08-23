

var app = angular.module('qapp', []);

app.controller('MainCtrl', function ($scope, $http, $timeout) {
    $scope.myDate = new Date();
    $scope.isOpen = true;

    $("#custDetails").hide();
    $("#custItemDetails").hide();
    $("#shipmentDetails").hide();

    //Load Data to Customer DropdownList
    $scope.GetData = function () {
        $http({
            method: 'GET',
            url: '/Customer/GetCustomerList'
        }).
          then(function (response) {
              $scope.customeDetails = response.data;
          }, function () {
              alert("Error Occur");
          })
    };

    //Get Customer Details on Dropdown Change
    $scope.GetCustomerDetails = function () {
        $("#custDetails").hide();
        $("#custItemDetails").hide();
        $("#shipmentDetails").hide();
        if ($scope.cust)
        {
            $("#custDetails").show();
            $("#custItemDetails").show();
            $("#shipmentDetails").show();
            $http({
                method: 'POST',
                url: '/Customer/GetCustDetails/',
                data: JSON.stringify({ CustomerID: $scope.cust })
            }).
                  then(function (response) {
                      $scope.PrimaryMail = response.data.PrimaryMailID;
                      $scope.PrimayPhone = response.data.PrimaryPhoneNo;
                      $scope.PersonName = response.data.ContactPersonName;
                      $scope.CEOName = response.data.CEOName;
                      $scope.Website = response.data.Website;
                      $scope.PersonNo = response.data.ContactPersonNumber;
                      $scope.GSTNo = response.data.GSTNO;
                      $scope.Adhar = response.data.Adhar;
                      $scope.PAN = response.data.PAN;

                      $scope.BillingAddress = response.data.BillingAddress;
                      $scope.BillingAddress1 = response.data.BillingAddress1;
                      $scope.BillingCity = response.data.BillingCity;
                      $scope.BillingState = response.data.BillingState;
                      $scope.BillingCountry = response.data.BillingCountry;
                      $scope.BillingPincode = response.data.BillingPincode;

                      $scope.ShippingAddress = response.data.ShippingAddress;
                      $scope.ShippingAddress1 = response.data.ShippingAddress1;
                      $scope.ShippingCity = response.data.ShippingCity;
                      $scope.ShippingState = response.data.ShippingState;
                      $scope.ShippingCountry = response.data.ShippingCountry;
                      $scope.ShippingPincode = response.data.ShippingPincode;

                  });
        }
    };

    //Add New rows to table
    $scope.rows = [{}];
    $scope.addRow = function () {
        $scope.rows.push({
        });
        $scope.total_amount();
    };

    //Remove rows from table
    $scope.remove = function (index) {
        if ($scope.rows.length > 1)
            $scope.rows.splice(index, 1);
        else
            alert("One Line is required");
    };

    //Get Product Details on Product Dropdown change
    $scope.getProductDetails = function (row, index) {
        if ($scope.rows.length > 1) {
            var i = 0;
            angular.forEach($scope.rows, function (selected) {
                if (selected.item_code == row.item_code && i != index) {
                    $scope.rows.splice(index, 1);
                    alert("Item already selected.Please Select another Item.");
                }
                i = i + 1;
            });
        }

        //Assign Zero to below fields
        angular.forEach($scope.product, function (p) {
            if (p.item_code == row.item_code) {
                row.item_value = p.item_value;
                row.parCode = p.parCode;
                row.item_CGST = 0;
                row.item_SGST =0;
                row.Tax =0;
                row.ItemTotal = 0;
            }
        })      
    }

    //Calculate Total Amount
    $scope.total_amount = function () {
        var total = 0;
        $scope.rows.forEach(function (row) {
            total += row.ItemTotal;
        });
        $scope.total = total;
        return total;
    };

    //Discount Calculation 
    $scope.calItemTotal = function (index) {
        calItemTot(index);
    };
    function calItemTot(index) {
        var itemValue = 0;
        var tot=0;
        itemValue = $scope.rows[index].item_value;
        var cgst = $scope.rows[index].item_CGST;
        var sgst = $scope.rows[index].item_SGST;
        var tax = parseInt(cgst) + parseInt(sgst);
        var calamount = parseInt(itemValue) / parseInt(tax) * 100;
        tot =  parseInt(itemValue) + parseInt(calamount);
        $scope.rows[index].ItemTotal = tot;
    }
    //Sample Product Details
    $scope.product = [
        {
            "item_code": 1001,
            "item_value": 150,
            "parCode": "996713",
            "item_description": "Documentation Charges"
        },
        {
            "item_code": 1002,
            "item_value": 1500,
            "parCode": "996713",
            "item_description": "Customs Clearance Charges"
        },
        {
            "item_code": 1003,
            "item_value": 500,
            "parCode": "996713",
            "item_description": "AD Code & IFSC Code Reg"
        },
        {
            "item_code": 1004,
            "item_value": 1200,
            "parCode": "996712",
            "item_description": "Transport Charges"
        },
        {
            "item_code": 1005,
            "item_value": 350,
            "parCode": "996711",
            "item_description": "AAI Charges"
        },
        {
            "item_code": 1006,
            "item_value": 1350,
            "parCode": "996713",
            "item_description": "AAI Excess Weight"
        },
        {
            "item_code": 1007,
            "item_value": 450,
            "parCode": "996713",
            "item_description": "Palletizatin and Parking Charges"
        },
        {
            "item_code": 1008,
            "item_value": 850,
            "parCode": "996713",
            "item_description": "Air Freight Charges"
        },
        {
            "item_code": 1009,
            "item_value": 600,
            "parCode": "996513",
            "item_description": "Airway Bill Fee"
        },
        {
            "item_code": 1010,
            "item_value": 900,
            "parCode": "996763",
            "item_description": "Airline Processing Charges 250GM"
        },
        {
            "item_code": 1011,
            "item_value": 200,
            "parCode": "996763",
            "item_description": "FOUNDATION CREAM"
        }]

    //Save Quote
    $scope.create = function () {
        $scope.QuoteDetails = {};
        $scope.QuoteDetails.CustomerID = $scope.cust;
        $scope.QuoteDetails.PrimaryMailID = $scope.PrimaryMail;
        $scope.QuoteDetails.PrimaryPhoneNo = $scope.PrimayPhone;
        $scope.QuoteDetails.ContactPersonName = $scope.PersonName;
        $scope.QuoteDetails.ContactPersonNo = $scope.PersonNo;
        $scope.QuoteDetails.BillingAddress = $scope.BillingAddress;
        $scope.QuoteDetails.BillingAddress1 = $scope.BillingAddress1;
        $scope.QuoteDetails.BillingCity = $scope.BillingCity;
        $scope.QuoteDetails.BillingState = $scope.BillingState;
        $scope.QuoteDetails.BillingCountry = $scope.BillingCountry;
        $scope.QuoteDetails.BillingPincode = $scope.BillingPincode;
        $scope.QuoteDetails.ShippingAddress = $scope.ShippingAddress;
        $scope.QuoteDetails.ShippingAddress1 = $scope.ShippingAddress1;
        $scope.QuoteDetails.ShippingCity = $scope.ShippingCity;
        $scope.QuoteDetails.ShippingState = $scope.ShippingState;
        $scope.QuoteDetails.ShippingCountry = $scope.ShippingCountry;
        $scope.QuoteDetails.ShippingPincode = $scope.ShippingPincode;
        $scope.QuoteDetails.TotalAmount = $scope.total;

        //Product Items Detail
        $scope.QuoteItems = [];
        $scope.items = {};
        angular.forEach($scope.rows, function (quoteDetail) {
            $scope.items.ProductID = quoteDetail.item_code;
            $scope.items.Quantity = quoteDetail.quantity;
            $scope.items.UOM = quoteDetail.uom;
            $scope.items.MRP = quoteDetail.product_mrp;
            $scope.items.Discount = quoteDetail.product_discount;
            $scope.items.ItemTotal = quoteDetail.amount;
            $scope.QuoteItems.push($scope.items);
        });
        $scope.QuoteDetails.QuoteItemsList = $scope.QuoteItems;

        $http({
            method: "post",
            url: "http://localhost:50480/Quote/SaveQuote",
            datatype: "json",
            data: JSON.stringify($scope.QuoteDetails)
        }).then(function (response) {
            alert(response.data);

        })
    };
});