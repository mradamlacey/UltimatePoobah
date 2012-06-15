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
    /**
    * Datastore is responsible for persisting and providing data from 
    * the Data Manager.
    */
    mstats.dataStore = {
        /**
        * _data stores the data used by datastore's get and set methods
        * @private
        */
        _data: {},

        /**
        * Gets data from the datastore
        *
        * @param {string} token  An identifier for retrieving associated data
        */
        get: function (token) {
            return this._data[token];
        },

        /**
        * Persists data in the datastore
        *
        * @param {string} token    An identifier for the stored data
        * @param {mixed} payload   A blob of data
        */
        set: function (token, payload) {
            // Store the data
            this._data[token] = payload;
        },

        /**
        * Removes an item from the data store
        *
        * @param {string} token    An identifier for the stored data
        */
        clear: function (token) {
            this._data[token] = undefined;
        },

        /**
        * Clears all data from the data store
        */
        clearAll: function () {
            this._data = {};
        }
    };

    /**
    * Data Manager is responsible for fetching data, storing it, 
    * and using callbacks to let callers know when that data is ready.
    */
    mstats.dataManager = {
        dataDefaults: {
            dataType: 'json',
            type: 'POST'
        },

        /**
        * When required, the data request URL will be modified to account for the 
        * webiste being deployed to a virtual directory instead of the website root. 
        *
        * Makes an ajax call to the specified endpoint to retrieve data.If sucessful 
        * stores the data in the data cache and calls the success callback.  
        *
        * This method mimics the options of $.ajax where appropriate.
        *
        * @param {object} options : Options object that maps to the ajax options object.
        *   this object must include the following fields:
        *       url : the url for the call
        *       success: a callback called on successful completion of the operation.
        */
        sendRequest: function (options) {
            // getRelativeEndpointUrl ensures the URL is relative to the website root.
            var that = mstats.dataManager,
                normalizedUrl = mstats.getRelativeEndpointUrl(options.url),
                cachedData = mstats.dataStore.get(normalizedUrl),
                callerOptions = $.extend({ cache:true }, that.dataDefaults, options, { url: normalizedUrl });
            
            if (callerOptions.cache && cachedData) {
                options.success(cachedData);
                return;
            }

            callerOptions.success = function (data) {
                if (callerOptions.cache) {
                    mstats.dataStore.set(normalizedUrl, data);
                }
                options.success(data);
            };

            $.ajax(callerOptions);
        },
        
        /**
        * resetData will clear the specified data from the cache so subsequent calls
        * to get the data will result in returning to the server for the data
        */
        resetData: function (endpoint) {
            mstats.dataStore.clear(mstats.getRelativeEndpointUrl(endpoint));
        }
    };

} (this.mstats = this.mstats || {}, jQuery));
