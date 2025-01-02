var webGLHelper = {
    saveDataToIndexedDB : async function(dbName, storeName, key, value) {
        if (!('indexedDB' in window)) {
            console.log("This browser doesn't support IndexedDB");
            return;
        }
        
        try{
            const dbPromise = await new Promise((resolve, reject) => {
                const request = indexedDB.open(UTF8ToString(dbName), 1);
                const _storeName = UTF8ToString(storeName);
                const _key = UTF8ToString(key);
                const _value = UTF8ToString(value);
                 
                request.onupgradeneeded = function(event) {
                    const db = event.target.result;

                    if (!db.objectStoreNames.contains(_storeName)) {
                        const store = db.createObjectStore(_storeName, { keyPath: "id" });
                        store.createIndex("key", "key", { unique: false });
                        store.createIndex("value", "value", { unique: false });
                        console.log("Object Stored Is Created " + _storeName);
                    }
                };
                
                request.onsuccess = function(event) {
                    const db = event.target.result;
                    const transaction = db.transaction([_storeName],"readwrite");
                    const objectStore = transaction.objectStore(_storeName);
                    const data = {
                                    id: key,
                                    key: _key,
                                    value: _value
                                 };
                    objectStore.add(data);
                    resolve(db);
                };
                request.onerror = function(event) {
                    reject(event.target.error);
                };
            });
            console.log(`Database '${UTF8ToString(dbName)}' is ready and store '${_storeName}' has been created.`);
        }
        catch(err){
            console.error('Error creating store:', err);
        }
    },
       
    loadDataFromIndexedDB : function(dbName, storeName, key) {
        let request = indexedDB.open(dbName, 1);
    
        request.onsuccess = function (event) {
            let db = event.target.result;
            let transaction = db.transaction(storeName, "readonly");
            let store = transaction.objectStore(storeName);
            let dataRequest = store.get(key);
    
            dataRequest.onsuccess = function (event) {
                if (event.target.result) {
                    console.log(" value ===> " + event.target.result.value);
                    //callback(event.target.result.value);
                } else {
                    console.log("No data found for the given key");
                    //callback(null);
                }
            };
        };
    
        request.onerror = function (event) {
            console.log("Error opening IndexedDB: " + event.target.error);
        };
    }
};
mergeInto(LibraryManager.library, webGLHelper);
