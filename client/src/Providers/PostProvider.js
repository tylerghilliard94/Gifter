import React, { useState, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";

export const PostContext = React.createContext();

export const PostProvider = (props) => {
    const [posts, setPosts] = useState([]);
    const { getToken } = useContext(UserProfileContext);

    const getAllPosts = () => {
        getToken().then((token) => fetch("/api/post/getwithcomments", {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
            .then((res) => res.json())
            .then(setPosts));
    };

    const addPost = (post) => {
        getToken().then((token) => fetch("/api/post", {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(post)
        }).then(resp => {
            if (resp.ok) {
                return resp.json();
            }
            throw new Error("Unauthorized");
        }))
    };
    const getAllSearch = (search) => {
        getToken().then((token) => fetch(`/api/post/search?q=${search}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }))
            .then((res) => res.json())
            .then(setPosts);
    };
    const getPost = (id) => {
        getToken().then((token) => fetch(`/api/post/GetByIdWithComments/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        })).then((res) => res.json());
    };

    const getAllPostsByUser = (id) => {
        getToken().then((token) => fetch(`/api/post/User/${id}`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }))
            .then((res) => res.json())
            .then(setPosts);
    };
    return (
        <PostContext.Provider value={{ posts, getAllPosts, addPost, getAllSearch, getPost, getAllPostsByUser }}>
            {props.children}
        </PostContext.Provider>
    );
};