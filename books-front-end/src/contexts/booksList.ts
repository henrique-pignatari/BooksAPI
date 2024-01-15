"use client"
import { useContext } from "react";
import { listProviderFactory } from "./factories/listsFactory";
import { BOOKS_URL } from "@/global/urls";

type Book = {
  title: string;
}

const {context, ProviderElement: BooksListProvider} = listProviderFactory<Book>({
  baseUrl: BOOKS_URL
});

const useBooksList = () => useContext(context)

export{
  useBooksList,
  BooksListProvider
}