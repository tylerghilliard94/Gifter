import React, { useContext, useState } from "react";
import { PostContext } from "../Providers/PostProvider";
import { Form, FormGroup, Label, Input, Button } from "reactstrap";

const PostForm = () => {

    const [post, setPost] = useState({ Title: "", ImageUrl: "", Caption: "", UserProfileId: 1, DateCreated: "" })
    const { getAllPosts, addPost } = useContext(PostContext);

    const handleNewPost = (event) => {
        event.preventDefault();
        addPost(post).then(() => {
            getAllPosts();
        })
    }
    const handleFieldChange = (event) => {
        const stateToChange = { ...post };
        stateToChange[event.target.id] = event.target.value;
        setPost(stateToChange);
    }

    return (
        <Form className="postForm" onSubmit={handleNewPost}>
            <FormGroup>
                <Label className="postTitleLabel">Title</Label>
                <Input
                    className="newPost"
                    onChange={handleFieldChange}
                    type="text"
                    id="Title"
                    placeholder="Enter Title"
                />
            </FormGroup>
            <FormGroup>
                <Label className="postImageUrlLabel">Image Url</Label>
                <Input
                    className="newPost"
                    onChange={handleFieldChange}
                    type="text"
                    id="ImageUrl"
                    placeholder="Enter Image Url"
                />

            </FormGroup>
            <FormGroup>
                <Label className="CaptionLabel">Caption</Label>
                <Input
                    className="newPost"
                    onChange={handleFieldChange}
                    type="text"
                    id="Caption"
                    placeholder="Caption"
                />
            </FormGroup>

            <FormGroup>
                <Label className="DateCreatedLabel">
                    Date Created
          </Label>
                <Input
                    className="newPost"
                    onChange={handleFieldChange}
                    type="datetime-local"
                    id="DateCreated"
                    placeholder=""
                />
            </FormGroup>

            <Button
                className="postButton"
                onClick={handleNewPost}
                variant="custom"
                type="submit"
            >
                Save Post
        </Button>
        </Form>
    )
}
export default PostForm


