// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let list = document.querySelectorAll(".list li");
let box = document.querySelectorAll(".box");

list.forEach((el) => {
    el.addEventListener("click", (e) => {
        list.forEach((el1) => {
            el1.style.color = "#000";
        })
        e.target.style.color = "#d4a373"
        box.forEach((el2) => {
            el2.style.display = "none";
        })
        document.querySelectorAll(e.target.dataset.color).forEach((el3) => {
            el3.style.display = "flex";
        })
    })
})
// 导入所需的模块和依赖项
const express = require('express');
const multer = require('multer'); // 用于处理文件上传
const fs = require('fs');
const mysql = require('mysql');

const app = express();

// 创建数据库连接
const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '33258699',
    database: 'utslover'
});

// 配置图像上传的存储位置和文件名
const storage = multer.diskStorage({
    destination: (_req, _file, cb) => {
        cb(null, 'uploads/'); // 图像存储的目录
    },
    filename: (req, file, cb) => {
        const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
        cb(null, file.fieldname + '-' + uniqueSuffix + '.jpg'); // 图像的文件名
    }
});

// 创建Multer实例
const upload = multer({ storage: storage });

// 处理图像上传请求
app.post('/upload', upload.single('image'), (req, res) => {
    const file = req.file;

    if (!file) {
        return res.status(400).json({ error: 'No image uploaded' });
    }

    // 将图像信息存储到数据库
    const imagePath = file.path; // 图像文件的路径
    const imageFileName = file.filename; // 图像文件的文件名

    const sql = 'INSERT INTO menu (path, filename) VALUES (?, ?)';
    db.query(sql, [imagePath, imageFileName], (err, result) => {
        if (err) {
            console.log(err);
            return res.status(500).json({ error: 'Failed to store image in database' });
        }

        res.status(200).json({ message: 'Image uploaded and stored in database' });
    });
});

// 启动服务器
app.listen(3000, () => {
    console.log('Server is running on port 3000');
});
