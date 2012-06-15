//===================================================================================
// Microsoft patterns & practices
// Silk : Web Client Guidance
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
(function (mstats, $) {

    mstats.events = {

        status: 'status',

        vehicle: {
            details: {
                selected: 'details/selected'
            },
            fillups: {
                selected: 'fillups/selected'
            },
            reminders: {
                selected: 'reminders/selected',
                fulfilled: 'reminders/fulfilled'
            },
            add: {
                selected: 'add/selected'
            },
            deleted: 'delete/succeeded'
        },

        dashboard: {
            selected: 'dashboard/selected'
        },
        charts: {
            selected: 'charts/selected'
        }

    };

}(this.mstats = this.mstats || {}, jQuery));
