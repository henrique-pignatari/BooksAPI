"use client"
import { ReactNode, useContext } from "react";
import { listProviderFactory } from "./factories/listsFactory";
import { BOOKS_URL } from "@/global/urls";

type Book = {
  title: string;
}

type BooksProviderProps = {
  children: ReactNode;
}

const {context, ProviderElement} = listProviderFactory<Book>({
  baseUrl: BOOKS_URL
});

const BooksListProvider = ({children}: BooksProviderProps) => {
  return(
    ProviderElement(children)
  )
}

const useBooksList = () => {
  return useContext(context)
}

export{
  useBooksList,
  BooksListProvider
}