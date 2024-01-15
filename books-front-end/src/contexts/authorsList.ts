"use client"
import { useContext } from "react";
import { listProviderFactory } from "./factories/listsFactory";
import { AUTHORS_URL } from "@/global/urls";

type Author = {
  id: string;
  name: string;
}

const {context, ProviderElement: AuthorsListProvider} = listProviderFactory<Author>({
  baseUrl: AUTHORS_URL
})

const useAuthorsList = () => useContext(context)

export{
  useAuthorsList,
  AuthorsListProvider
}