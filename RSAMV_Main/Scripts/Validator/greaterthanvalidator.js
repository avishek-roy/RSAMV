(function ($) {
    debugger;
    $.validator.addMethod( "greaterthan", function ( value, element, params )
    {
        debugger;
        var propertyname = params['comparewith'];
        var allowequal = params['allowequal'];
        var propValue = $( '#' + propertyname ).val();
        //Modified By Avishek date:Mar-31-2015
        //Start
        var datefrom = [];
        datefrom = value.split( '/' );
        var date1 = datefrom[1] + '/' + datefrom[0] + '/' + datefrom[2];

        var dateto = [];
        dateto = propValue.split( '/' );
        var date2 = dateto[1] + '/' + dateto[0] + '/' + dateto[2];
        date1 = new Date( date1 );
        date2 = new Date( date2 );

        if ( allowequal )
        {
            if ( date1 >= date2 ){
                //End
                //if (value >= propValue) {
                return true;
            }
            return false;
        }
        else {
            if ( date1 >= date2 ){
            //if (value >= propValue) {
                return true;
            }
            return false;
        }
    });
    $.validator.unobtrusive.adapters.add("greaterthan", ["comparewith", "allowequal"], function (options) {
        debugger;
        options.rules["greaterthan"] = options.params;
        if (options.message) {
            options.messages['greaterthan'] = options.message;
        }
    });
})(jQuery);