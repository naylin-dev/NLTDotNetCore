const tblBlog = "blogs";
let blogId = null;

getBlogsTable();

// readBlog();
// createBlog();
// updateBlog("c023b9da-78ad-4d32-8bd8-b2c5eb037d9d", "update title", "update author", "update content");
// deleteBlog("c023b9da-78ad-4d32-8bd8-b2c5eb037d9d");


function readBlog() {
    let lst = getBlogs();
    console.log(lst);
}

function editBlog(id) {
    let lst = getBlogs();

    const items = lst.filter(blog => blog.id === id);

    if (items.length === 0) {
        errorMessage("Blog not found");
        return;
    }

    const item = items[0];

    blogId = item.id;
    $('#txt-title').val(item.title);
    $('#txt-author').val(item.author);
    $('#txt-content').val(item.content);

    $('#txt-title').focus();
}

function createBlog(title, author, content) {
    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content,
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);

    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Saving Successful.");
    clearControls();
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();

    const items = lst.filter(blog => blog.id === id);

    if (items.length === 0) {
        errorMessage("Blog not found");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(blog => blog.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);

    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Updating Successful.");
    clearControls();
}

function deleteBlog(id) {
    let result = confirm("Are you sure you want to delete?");

    if (!result) {
        return;
    }

    let lst = getBlogs();

    const items = lst.filter(blog => blog.id === id);

    if (items.length === 0) {
        errorMessage("Blog not found");
        return;
    }

    lst = lst.filter(blog => blog.id !== id);

    const jsonBlog = JSON.stringify(lst);

    localStorage.setItem(tblBlog, jsonBlog);
    successMessage("Deleting Successful.");
    getBlogsTable();
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

function successMessage(message) {
    alert(message);
}

function errorMessage(message) {
    alert(message);
}

function clearControls() {
    $('#txt-title').val('');
    $('#txt-author').val('');
    $('#txt-content').val('');

    $('#txt-title').focus();
}

function getBlogsTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = "";
    lst.forEach(item => {
        const htmlRow = `
            <tr>
                <td>
                    <button type="button" class="btn btn-warning" onclick="editBlog('${item.id}')">Edit</button>
                    <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button>
                </td>
                <td>${++count}</td>
                <td>${item.title}</td>
                <td>${item.author}</td>
                <td>${item.content}</td>
            </td>
        `;
        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}

$('#btn-save').click(function () {
    const title = $('#txt-title').val();
    const author = $('#txt-author').val();
    const content = $('#txt-content').val();

    if (blogId === null) {
        createBlog(title, author, content);
    } else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }

    getBlogsTable();
})

$('#btn-cancel').click(function () {
    clearControls();
})