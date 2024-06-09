const tblProduct = "product";
const tblShoppingCart = "shopping-cart";
let productId = null;

/***********/
/* Product */
/***********/

getProductsTable();

function getProducts() {
    const products = localStorage.getItem(tblProduct);

    let lst = [];
    if (products !== null) {
        lst = JSON.parse(products);
    }
    return lst;
}

function getProductsTable() {
    const lst = getProducts();
    let count = 0;

    let productData = [];
    lst.forEach(item => {
        productData.push([
            `<button type="button" class="btn btn-warning" onclick="editProduct('${item.id}')">Edit</button>
            <button type="button" class="btn btn-danger" onclick="deleteProduct('${item.id}')">Delete</button>`,
            ++count,
            item.product_name,
            item.price,
            `<button type="button" class="btn btn-primary" onclick="addToCart('${item.id}')">Add to cart</button>`
        ])
    });

    new DataTable("#table-product", {
        destroy: true,
        data: productData,
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ]
    });
}

function createProduct(productName, price) {
    let lst = getProducts();

    const requestModel = {
        id: uuidv4(),
        product_name: productName,
        price: price,
    };

    lst.push(requestModel);

    const jsonProduct = JSON.stringify(lst);

    localStorage.setItem(tblProduct, jsonProduct);

    successMessage("Saving Successful.");
    clearControls();
}

function editProduct(id) {
    let lst = getProducts();

    const items = lst.filter(product => product.id === id);

    if (items.length === 0) {
        errorMessage("Product not found");
        return;
    }

    const item = items[0];

    productId = item.id;
    $('#txt-product-name').val(item.product_name);
    $('#txt-price').val(item.price);

    $('#txt-product-name').focus();
}

function updateProduct(id, productName, price) {
    let lst = getProducts();

    const items = lst.filter(product => product.id === id);

    if (items.length === 0) {
        errorMessage("Product not found");
        return;
    }

    const item = items[0];
    item.product_name = productName;
    item.price = price

    const index = lst.findIndex(product => product.id === id);
    lst[index] = item;

    const jsonProduct = JSON.stringify(lst);

    localStorage.setItem(tblProduct, jsonProduct);

    successMessage("Updating Successful.");
    clearControls();
}

function deleteProduct(id) {
    confirmMessage("Are you sure you want to delete?").then(
        function (value) {
            let lst = getProducts();

            const items = lst.filter(product => product.id === id);

            if (items.length === 0) {
                errorMessage("Product not found");
                return;
            }

            lst = lst.filter(product => product.id !== id);

            const jsonProduct = JSON.stringify(lst);

            localStorage.setItem(tblProduct, jsonProduct);
            successMessage("Deleting Successful.");
            getProductsTable();
        }
    )
}

function clearControls() {
    $('#txt-product-name').val('');
    $('#txt-price').val('');

    $('#txt-product-name').focus();
}

$('#btn-save').click(function () {
    const productName = $('#txt-product-name').val();
    const price = $('#txt-price').val();

    if (productId === null) {
        createProduct(productName, price);
    } else {
        updateProduct(productId, productName, price);
        productId = null;
    }

    getProductsTable();
})

$('#btn-cancel').click(function () {
    clearControls();
})

/*****************/
/* Shopping Cart */
/*****************/

getShoppingCartsTable();

function getShoppingCarts() {
    const shoppingCarts = localStorage.getItem(tblShoppingCart);

    let lst = [];
    if (shoppingCarts !== null) {
        lst = JSON.parse(shoppingCarts);
    }
    return lst;
}

function getShoppingCartsTable() {
    const lst = getShoppingCarts();
    let count = 0;
    let shoppingCartData = [];

    lst.forEach(item => {
        shoppingCartData.push([
            `<button type="button" class="btn btn-danger" onclick="deleteShoppingCart('${item.id}')">Delete</button>`,
            ++count,
            item.product_name,
            item.price,
            item.quantity,
            item.total,
        ]);
    });

    new DataTable("#table-shopping-cart", {
        destroy: true,
        data: shoppingCartData,
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ],
        footerCallback: function (row, data, start, end, display) {
            let api = this.api();

            // Remove the formatting to get integer data for summation
            let intVal = function (i) {
                return typeof i === 'string'
                    ? i.replace(/[\$,]/g, '') * 1
                    : typeof i === 'number'
                        ? i
                        : 0;
            };

            // Total over all pages
            total = api
                .column(5)
                .data()
                .reduce((a, b) => intVal(a) + intVal(b), 0);

            // Total over this page
            pageTotal = api
                .column(5, { page: 'current' })
                .data()
                .reduce((a, b) => intVal(a) + intVal(b), 0);

            // Update footer
            api.column(5).footer().innerHTML =
                '$' + pageTotal + ' ( $' + total + ' total)';

            // Total over all pages
            totalQuantity = api
                .column(4)
                .data()
                .reduce((a, b) => intVal(a) + intVal(b), 0);

            // Total over this page
            pageTotalQuantity = api
                .column(4, { page: 'current' })
                .data()
                .reduce((a, b) => intVal(a) + intVal(b), 0);

            // Update footer
            api.column(4).footer().innerHTML =
                pageTotalQuantity + ' (' + totalQuantity + ' total)';
        }
    });
}

function addToCart(id) {
    const lst = getShoppingCarts();

    const items = lst.filter(shoppingCart => shoppingCart.product_id === id);

    if (items.length > 0) {
        const item = items[0];
        item.quantity += 1;
        item.total = item.price * item.quantity;

        const index = lst.findIndex(shoppingCart => shoppingCart.product_id === id);
        lst[index] = item;

        const jsonShoppingCart = JSON.stringify(lst);

        localStorage.setItem(tblShoppingCart, jsonShoppingCart);

        successMessage("Adding Successful.");
    } else {
        const products = getProducts();

        const items = products.filter(product => product.id === id);

        if (items.length === 0) {
            errorMessage("Product not found");
            return;
        }

        const item = items[0];

        const requestModel = {
            id: uuidv4(),
            product_id: item.id,
            product_name: item.product_name,
            price: item.price,
            quantity: 1,
            total: item.price,
        };

        lst.push(requestModel);

        const jsonShoppingCart = JSON.stringify(lst);

        localStorage.setItem(tblShoppingCart, jsonShoppingCart);

        successMessage("Adding Successful.");
    }
    getShoppingCartsTable();
}


function deleteShoppingCart(id) {
    confirmMessage("Are you sure you want to delete?").then(
        function (value) {
            let lst = getShoppingCarts();

            const items = lst.filter(shoppingCart => shoppingCart.id === id);

            if (items.length === 0) {
                errorMessage("Shopping Cart not found");
                return;
            }

            lst = lst.filter(shoppingCart => shoppingCart.id !== id);

            const jsonShoppingCart = JSON.stringify(lst);

            localStorage.setItem(tblShoppingCart, jsonShoppingCart);
            successMessage("Deleting Successful.");
            getShoppingCartsTable();
        }
    )
}