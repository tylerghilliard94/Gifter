import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";

const Comment = ({ comment }) => {
    return (

        <p>{comment.message}</p>

    );
};

export default Comment;