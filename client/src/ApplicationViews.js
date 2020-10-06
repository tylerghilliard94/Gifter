import React, { useContext } from "react";
import { Switch, Route, Redirect, BrowserRouter as Router } from "react-router-dom";
import { UserProfileContext } from "./Providers/UserProfileProvider";
import Register from "./Components/Register";
import PostList from "./Components/PostList";
import PostForm from "./Components/PostForm";
import PostDetails from "./Components/PostDetails"
import UserPosts from "./Components/UserPosts";
import Login from "./Components/Login";

const ApplicationViews = () => {
    const { isLoggedIn } = useContext(UserProfileContext);
    return (
        <>

            <Route path="/" exact>
                {isLoggedIn ? <PostList /> : <Redirect to="/login" />}
            </Route>

            <Route path="/posts/add" exact>
                {isLoggedIn ? <PostForm /> : <Redirect to="/login" />}
            </Route>
            <Route path="/posts/details/:id" exact>
                <PostDetails />
            </Route>
            <Route path="/user/:id">{isLoggedIn ? <PostDetails /> : <Redirect to="/login" />} </Route>
            <Route path="/login">
                <Login />
            </Route>

            <Route path="/register">
                <Register />
            </Route>

        </>

    );
};

export default ApplicationViews;