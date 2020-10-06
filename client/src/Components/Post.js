import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import Comment from "../Components/Comment"
import { NavLink, BrowserRouter as Router } from "react-router-dom";

const Post = ({ post }) => {
    return (

        <Card className="m-4">
            <p className="text-left px-2">Posted by: <NavLink to={`/user/${post.userProfile.id}`}>{post.userProfile.name}</NavLink></p>
            <CardImg top src={post.imageUrl} alt={post.title} />
            <CardBody>
                <NavLink to={`/posts/details/${post.id}`}>
                    <strong>{post.title}</strong>
                </NavLink>
                <p>{post.caption}</p>
                <p>Comments</p>

                {post.comments.map(comm => {
                    return (<Comment comment={comm} />)

                })}
            </CardBody>
        </Card>

    );
};

export default Post;